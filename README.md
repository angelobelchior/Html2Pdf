![Html2Pdf Logo](https://raw.githubusercontent.com/angelobelchior/Html2Pdf/refs/heads/main/src/icon.png)

# Html 2 Pdf

[![.NET](https://github.com/angelobelchior/Html2Pdf/actions/workflows/dotnet.yml/badge.svg)](https://github.com/angelobelchior/Html2Pdf/actions/workflows/dotnet.yml)

## The best tool to convert HTML to PDF in .NET

Html2Pdf.Lib is an Open Source library with an [MIT license](https://en.wikipedia.org/wiki/MIT_License) that converts an HTML file into a PDF file.

This library was built using [wkhtmltopdf](https://wkhtmltopdf.org/), which is a command-line tool for converting HTML files to PDFs using the [QT Webkit](https://wiki.qt.io/Qt_WebKit) rendering engine.

No secret: The C# code simply calls the wkhtmltopdf executable and passes the necessary parameters. It's that simple: ```wkhtmltopdf -q --margin-bottom 10 --margin-left 10 --margin-right 10 --margin-top 10 -s A4```

There are many other parameters to configure the conversion, such as page size, margins, orientation, image quality, etc.

However, it is important to note that [wkhtmltopdf](https://github.com/wkhtmltopdf/wkhtmltopdf) was discontinued in 2020, with its [repository](https://github.com/wkhtmltopdf/wkhtmltopdf) archived in 2023 and no longer supported. But it is still a widely used tool that works very well.

## How to Install

```
dotnet add package Html2Pdf.Lib
```

## How to Use

First, we need to define the conversion parameters. For this, we use the [Arguments class](https://github.com/angelobelchior/Html2Pdf/blob/main/src/Arguments.cs).

These parameters are optional and can be configured as needed.

Basically, they are the same parameters that wkhtmltopdf accepts. If you want to know more, check out the [documentation](https://wkhtmltopdf.org/usage/wkhtmltopdf.txt).

```csharp
using Html2Pdf.Lib;

var arguments = new Arguments()
    // When jpeg compressing images use this quality (default 94)
    .SetImageQuality(80)

    // Do not print background
    .DoNotPrintBackground()

    // Do not load or print images
    .DoNotLoadOrPrintImages()

    // Do not use lossless compression on pdf objects
    .WithNoPdfCompression()

    // Do not make links to remote web pages
    .DisableExternalLinks()

    // Do not make local links
    .DisableInternalLinks()

    // The title of the generated pdf file (The title of the first document is used if not specified)
    .SetTitle("This is a sample PDF document")

    // Indicates whether the PDF should be generated in lower quality.
    .WithLowQuality()

    // Number of copies to print into the PDF file.
    .SetCopies(2)

    // Indicates whether the PDF should be generated in grayscale.
    .WithGrayScale()

    // Replace [name] with value in header and footer (repeatable)
    .Replace("HTML to PDF Test Page", "HTML to PDF Test Page - Sample 1")

    // Set the starting page number (default 0)
    .SetOffPageOffset(2)

    // Sets the page margins
    .SetPageMargins(10, 10, 10, 10)

    // Sets the page Width. Has priority over "SetPageSize" but "SetPageHeight" has to be also specified.
    .SetPageWidth(210)

    // Sets the page Height. Has priority over "SetPageSize" but "SetPageWidth" has to be also specified.
    .SetPageHeight(297)

    // Set the page Orientation
    .SetPageOrientation(PageOrientation.Landscape)

    // The default page size of the rendered document is A4.
    .SetPageSize(PageSize.A4)

    // Disable SmartSets the page size.
    .DisableSmartShrinking()

    // Turn HTML form fields into pdf form fields
    .EnableForms()

    // Display line below the header
    .DisplayHeaderLine()

    // Set header text
    .SetHeaderText("Header Text Sample 1", TextAlignment.Center, "Verdana", 15)

    // Spacing between footer and content in mm (default 0)
    .SetHeaderSpacing(23)

    // Display line above the footer
    .DisplayFooterLine()

    // Set footer text
    .SetFooterText("Footer Text Sample 1", TextAlignment.Center, "Verdana", 15)

    // Spacing between footer and content in mm (default 0)
    .SetFooterSpacing(23);
```

### It is possible to generate a PDF in four ways:

#### From an HTML Text

```csharp
var html = 
"""
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>HTML Simples</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            margin: 0;
            padding: 20px;
        }
        header {
            background: #007BFF;
            color: white;
            padding: 10px 0;
            text-align: center;
        }
        main {
            margin-top: 20px;
            text-align: center;
        }
        footer {
            margin-top: 20px;
            text-align: center;
            color: #555;
        }
    </style>
</head>
<body>
    <header>
        <h1>Hello World!</h1>
    </header>
    <main>
        <p>This is a Sample! Convert HTML to PDF</p>
    </main>
    <footer>
        <p>&copy; 2024 My Sample HTML</p>
    </footer>
</body>
</html>
""";

var byteArrayHtml = Converter.FromHtml(html, arguments);
```

#### From Url

```csharp
var url = new Uri("https://en.wikipedia.org/wiki/C_Sharp_(programming_language)");
var byteArrayUrl = Converter.FromUrl(url), arguments);
```

#### From an HTML template using Razor Syntax

```csharp
public record Product(string Name, decimal Price);
public record Order(string CustomerName, string CustomerAddress, string CustomerPhoneNumber, List<Product> Products);

var razorTemplate =
"""
<!DOCTYPE html>
<html lang="pt-br">
<head>
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

var order = new Order("Roberto Rivellino", "Rua São Jorge, 777", "+55 11 912345678", [
    new("Product 1", 9.99m),
    new("Product 2", 19.99m),
    new("Product 3", 29.99m)
]);
var byteArrayRazorTemplate = Converter.FromRazorTemplate(razorTemplate, order, arguments);
```

#### From an HTML template using Razor Syntax in Batch
```csharp
var order1 = new Order("Roberto Rivellino", "Rua São Jorge, 777", "+55 11 912345678", [
    new("Product 1", 9.99m),
    new("Product 2", 19.99m),
    new("Product 3", 29.99m)
]);
var byteArrayRazorTemplate = Converter.FromRazorTemplate(razorTemplate, order1, arguments);

var order2 = new Order("Sócrates", "Rua das Alamedas, 888", "+55 11 912345678", [
    new("Product 1", 2.99m),
    new("Product 2", 4.99m),
    new("Product 3", 6.99m)
]);

var order3 = new Order("Biro Biro", "Avenida das Orquídeas, 999", "+55 11 912345678", [
    new("Product 1", 3.99m),
    new("Product 2", 5.99m),
]);

var order4 = new Order("Casagrande", "Estrada das Flores, 456", "+55 11 912345678", [ ]);

var byteArrayRazorTemplateList = Converter.FromRazorTemplateBatch(razorTemplate, [ order1, order2, order3, order4 ], arguments);
for (int i = 0; i < byteArrayRazorTemplateList.Count; i++)
{
    var pdf = byteArrayRazorTemplateList.ElementAt(i);
    ...
}
```

## How to run the code locally

To run on macOS or Linux machines, you need to execute the command ```chmod +x ./wkhtmltopdf/[Operating System Name]/wkhtmltopdf``` to change the file permissions.  
Additionally, since the build process copies the executable files to a folder named after the operating system, you need to run the command ```umask 0022``` to ensure the copied executable retains the correct permissions.

If you are developing on a Windows machine, you need to run Visual Studio in Administrator mode.  
In some cases, you will need to perform the following steps:
- Right-click on the file `./wkhtmltopdf/Windows/wkhtmltopdf.exe`
- Go to "Properties" and click on the "Compatibility" tab
- Then click on "Change settings for all users"
- Check the option "Run this program as an administrator".
