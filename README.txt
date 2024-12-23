 _    _ _             _ ___  _____    _  __ 
 | |  | | |           | |__ \|  __ \  | |/ _|
 | |__| | |_ _ __ ___ | |  ) | |__) |_| | |_ 
 |  __  | __| '_ ` _ \| | / /|  ___/ _` |  _|
 | |  | | |_| | | | | | |/ /_| |  | (_| | |  
 |_|  |_|\__|_| |_| |_|_|____|_|   \__,_|_|  
                                             
                                             
The best tool to convert HTML to PDF in .NET
============================================

Html2Pdf.Lib is an Open Source library with an [MIT license](https://en.wikipedia.org/wiki/MIT_License) 
that converts an HTML file into a PDF file.

This library was built using [wkhtmltopdf](https://wkhtmltopdf.org/), 
which is a command-line tool for converting HTML files to PDFs using the [QT Webkit](https://wiki.qt.io/Qt_WebKit) 
rendering engine.

No secret: The C# code simply calls the wkhtmltopdf executable and passes the necessary parameters. 
It's that simple: ```wkhtmltopdf -q --margin-bottom 10 --margin-left 10 --margin-right 10 --margin-top 10 -s A4```

There are many other parameters to configure the conversion, such as page size, margins, orientation, image quality, etc.

Disclaimer
==========

However, it is important to note that [wkhtmltopdf](https://github.com/wkhtmltopdf/wkhtmltopdf) was discontinued in 2020, 
with its [repository](https://github.com/wkhtmltopdf/wkhtmltopdf) archived in 2023 and no longer supported. 
But it is still a widely used tool that works very well.

What's new in V0.2.0 (Break significant change!)
================================================

- Change main entrypoint to Html2Pdf
- Refactoring to fluent interface for all commands
- Improvements for async usage
- Removed command template using Razor Syntax in Batch
   - Now the implementation must be done by the application

It is possible to generate a PDF in three ways
==============================================

------------
From an HTML
------------

var pathToSamples = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

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

var resutfileHtml = await Html2Pdf
    .FromHtml(html)
    .SaveToAsync(Path.Combine(pathToSamples,"html2pdfHtml.pdf"), true /*return bytes*/, CancellationToken.None);
    //.RunAsync(CancellationToken.None); // return only bytes[]

var elptfilehml = resutfileHtml.Elapsedtime;

if (resutfileHtml.IsSuccess)
{
    var bytes = resutfileHtml.Content;
    var file = resutfileHtml.FileName; 
}
else
{
    var err = resutfileHtml.Error;
}

--------
From Url
--------

var pathToSamples = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

var resutfileUrl = await Html2Pdf
    .FromUrl(new Uri("https://en.wikipedia.org/wiki/C_Sharp_(programming_language)"))
    .SaveToAsync(Path.Combine(pathToSamples,"html2pdfurl.pdf"), true /*return bytes*/, CancellationToken.None);
    //.RunAsync(CancellationToken.None); // return only bytes[]

var elptfileurl = resutfileUrl.Elapsedtime;

if (resutfileUrl.IsSuccess)
{
    var bytes = resutfileUrl.Content;
    var file = resutfileUrl.FileName; 
}
else
{
    var err = resutfileUrl.Error;
}

----------------------------------------
From an HTML template using Razor Syntax
----------------------------------------

public record Product(string Name, decimal Price);
public record Order(string CustomerName, string CustomerAddress, string CustomerPhoneNumber, List<Product> Products);

var pathToSamples = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

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

var resutRazor = await Html2Pdf
    .FromRazorTemplate(razorTemplate,order)
    .SaveToAsync(Path.Combine("html2pdfRazorTemplate.pdf", true /*return bytes*/);
    //.RunAsync(CancellationToken.None); // return only bytes[]

var elptfilrazor = resutRazor.Elapsedtime;

if (resutRazor.IsSuccess)
{
    var bytes = resutRazor.Content;
    var file = resutRazor.FileName; 
}
else
{
    var err = resutRazor.Error;
} 


Running a set of models in parallel
===================================

public record Product(string Name, decimal Price);
public record Order(string CustomerName, string CustomerAddress, string CustomerPhoneNumber, List<Product> Products);

var pathToSamples = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

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

var lstrorder = new List<Order>
{
    new("Sócrates", "Rua das Alamedas, 888", "+55 11 912345678", [
    new("Product 1", 2.99m),
    new("Product 2", 4.99m),
    new("Product 3", 6.99m)
]),
    new("Biro Biro", "Avenida das Orquídeas, 999", "+55 11 912345678", [
    new("Product 1", 3.99m),
    new("Product 2", 5.99m),
]),
    new("Casagrande", "Estrada das Flores, 456", "+55 11 912345678", [])
};

var lsttask = new List<Task<Html2PdfResult>>();
for (int i = 0; i < lstrorder.Count; i++)
{
   lsttask.Add(Html2Pdf
        .Config((opt) =>
        {
            opt.PageMargins(5);
        })
        .FromRazorTemplate(razorTemplate, lstrorder.ElementAt(i))
        .TimeoutConvert(10000)
        .Runsync(Path.Combine(pathToSamples, $"html2pdfRazorTemplate{i+1}.pdf"), true /*return bytes*/, CancellationToken.None));
}
Task.WhenAll(lsttask).Wait();

foreach (var task in lsttask)
{

    elpt = task.Result.Elapsedtime;
    if (task.Result.IsSuccess)
    {
        var bytes = task.Result.Content;
    }
    else
    {
        var err = task.Result.Error;
    }
}

Configuration customization, logger integration and execution time limit (timeout)
==================================================================================

This library allows you to customize document settings, header, footer, page and behavior for each run.

//sample customize
var resut = await Html2Pdf
    .Config((opt) =>
        {
            opt.Copies(2)
             .ImageQuality(80)
             .PageOrientation(PageOrientation.Landscape)
             .Title("This is a sample PDF document")
             .Replace("HTML to PDF Test Page", "HTML to PDF Test Page - Sample 1")
             .HeaderText("Header Text Sample 1", TextAlignment.Center)
             .HeaderFont("Verdana", 10)
             .FooterText("Footer Text Sample 1", TextAlignment.Center)
             .FooterFont("Verdana", 10)
             .HasFooterLine(true)
             .HasHeaderLine(true)   
             .PageMargins(5);
             ...
        })
    .FromHtml(...)
    .Logger(...) // Ilogger instance 
    .TimeoutConvert(...) // execution time limit (Default 30000)
    .IgnoreImageErrors(true) // Ignore error Images (Default false)
    ...
}

Running with a custom configuration file
========================================

This library allows you to customize some global settings by publishing a json file along with the binaries. 

An example file is automatically published in your project folder "Html2PdfGlobalConfig" with default values.


Running on Docker
=================

Basically you need to install wkhtmltopdf. Below is an example of a docker file.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

# Install wkhtmltopdf
RUN apt-get -y update && apt-get -y upgrade
RUN apt-get -y install wkhtmltopdf
RUN wkhtmltopdf --version

USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["playground/OnDocker/Html2Pdf.OnDocker.csproj", "playground/OnDocker/"]
RUN dotnet restore "playground/OnDocker/Html2Pdf.OnDocker.csproj"
COPY . .
WORKDIR "/src/playground/OnDocker"
RUN dotnet build "Html2Pdf.OnDocker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Html2Pdf.OnDocker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Html2Pdf.OnDocker.dll"]

-------------------
Install wkhtmltopdf
-------------------

RUN apt-get -y update && apt-get -y upgrade
RUN apt-get -y install wkhtmltopdf
RUN wkhtmltopdf --version

This command should be right below ```FROM mcr.microsoft.com/dotnet/aspnet:<<version>> AS base```

You can get a complete example by accessing the link
[https://github.com/angelobelchior/Html2Pdf/tree/main/playground/OnDocker](https://github.com/angelobelchior/Html2Pdf/tree/main/playground/OnDocker)

Running on Azure App Services
=============================

To run on Azure App Services, you need to install the wkhtmltopdf executable. 
You can do this by adding the following startup command in the Azure App Service configuration:

startup-command: 'apt-get -y install wkhtmltopdf'

For more information, see the link below [https://learn.microsoft.com/en-us/answers/questions/1282899/how-does-startup-commands-work-on-an-azure-app-ser](https://learn.microsoft.com/en-us/answers/questions/1282899/how-does-startup-commands-work-on-an-azure-app-ser)

How to run the code locally
===========================

-----
macOS
-----

Install the [wkhtmltopdf](https://wkhtmltopdf.org/downloads.html) executable for macOS. Or use the following command to install it via Homebrew:

brew install wkhtmltopdf

-----
Linux
-----

Install the [wkhtmltopdf](https://wkhtmltopdf.org/downloads.html) executable for Linux. Or use the following command to install it via APT:

apt-get -y update && apt-get -y upgrade
apt-get -y install wkhtmltopdf

-------
Windows
-------

If you are developing on a Windows machine, you need to run Visual Studio in Administrator mode.  
In some cases, you will need to perform the following steps:
- Right-click on the file `./wkhtmltopdf/Windows/wkhtmltopdf.exe`
- Go to "Properties" and click on the "Compatibility" tab
- Then click on "Change settings for all users"
- Check the option "Run this program as an administrator".

Credits
-------

----------------
Top contributors
----------------

- [Fernando Cerqueira](https://github.com/FRACerqueira) (V.0.2.0)
    - Refactoring to fluent interface 
    - Improvements for async usage
    - Integration with logger and timeout option  
