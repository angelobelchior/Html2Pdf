using Html2Pdf.Lib;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();

var razorTemplate =
"""
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <title>Customer Details</title>
    <style>
        table {
            border-collapse: collapse;
            width: 100%;
        }
        th, td {
            border: 1px solid #ddd;
            padding: 8px;
        }
        th {
            background-color: #f4f4f4;
            text-align: left;
        }
        tr { 
            page-break-inside: avoid; 
        }
    </style>
</head>
<body>
    <h1>Customer Details</h1>
    <p><strong>Name:</strong> @Model.CustomerName</p>
    <p><strong>Address:</strong> @Model.CustomerAddress</p>
    <p><strong>Phone Number:</strong> @Model.CustomerPhoneNumber</p>

    <h2>Products (@Model.Products.Count)</h2>
    @if(Model.Products.Any())
    {
        <table>
            <thead>
                <tr>
                    <th>Product Name</th>
                    <th>Price</th>
                </tr>
            </thead>
            <tbody>
                @foreach (var product in Model.Products)
                {
                    <tr>
                        <td>@product.Name</td>
                        <td>@product.Price.ToString("C")</td>
                    </tr>
                }
            </tbody>
        </table>
    } 
    else
    {
        <p>No products found.</p>
    }
</body>
</html>
""";

app.MapGet("/get-pdf", () =>
    {
        var order = new Order("Roberto Rivellino", "Rua São Jorge, 777", "+55 11 912345678", [
            new("Product 1", 9.99m),
            new("Product 2", 19.99m),
            new("Product 3", 29.99m)
        ]);
        var resultpdf = Converter.FromRazorTemplate(
            razorTemplate, 
            order, 
            new Arguments().SetPageOrientation(PageOrientation.Landscape));
        if (resultpdf.HasValue)
        {
            return Results.File(resultpdf.Content!, Converter.ContentType);
        }
        return Results.InternalServerError(resultpdf.Error==null?"Erro Created PDF":resultpdf.Error.Message);
    })
    .WithName("GetPdf");

app.Run();

public record Product(string Name, decimal Price);
public record Order(string CustomerName, string CustomerAddress, string CustomerPhoneNumber, List<Product> Products);