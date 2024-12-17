![Html2Pdf Logo](https://raw.githubusercontent.com/angelobelchior/Html2Pdf/refs/heads/main/src/Html2Pdf.Lib.png)

# Html 2 Pdf

[![.NET](https://github.com/angelobelchior/Html2Pdf/actions/workflows/dotnet.yml/badge.svg)](https://github.com/angelobelchior/Html2Pdf/actions/workflows/dotnet.yml)

## Solução para converter HTML em PDF

Html2Pdf.Lib é uma biblioteca Open Source e com [licença MIT](https://pt.wikipedia.org/wiki/Licen%C3%A7a_MIT) que converte um arquivo HTML em um arquivo PDF.

Essa biblioteca foi feita utilizando o [wkhtmltopdf](https://wkhtmltopdf.org/), que é uma ferramenta de linha de comando para converter arquivos HTML em PDFs usando o Mecanismo de renderização [QT Webkit](https://wiki.qt.io/Qt_WebKit).

Não tem segredo: O código em csharp apenas chama o executável do wkhtmltopdf e passa os parâmetros necessários. Simples assim: ```wkhtmltopdf -q --margin-bottom 10 --margin-left 10 --margin-right 10 --margin-top 10 -s A4```

Existem muitos outros parâmetros para configurar a conversão, como tamanho da página, margens, orientação, qualidade das imagens, etc. 

Porém, é preciso destacar que o [wkhtmltopdf](https://github.com/wkhtmltopdf/wkhtmltopdf) foi descontinuado em 2020, tendo o seu [repositório](https://github.com/wkhtmltopdf/wkhtmltopdf) arquivado em 2023 e não tem mais suporte. Mas ainda é uma ferramenta muito utilizada e que funciona muito bem.

## Como Instalar

```
dotnet add package Html2Pdf.Lib
```

## Como Usar

Primeiramente, precisamos definir os parâmetros de conversão. Para isso, utilizamos a classe Arguments.

Esses parâmetros são opcionais e podem ser configurados conforme a necessidade.

Basicamente eles são os mesmos parâmetros que o wkhtmltopdf aceita. Caso queira saber mais, acesse a [documentação](https://wkhtmltopdf.org/usage/wkhtmltopdf.txt).
 
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

### É possível gerar um PDF de quatro formas:

#### A partir de um texto HTML

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

#### A partir de uma URL

```csharp
var url = new Uri("https://en.wikipedia.org/wiki/C_Sharp_(programming_language)");
var byteArrayUrl = Converter.FromUrl(url), arguments);
```

#### A partir de um template HTML utilizando o Razor

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

#### Em batch, a partir de um template HTML utilizando o Razor
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

## Como executar o código localmente

Para executar em máquinas com macOS ou Linux, você precisa executar o comando ```chmod +x ./wkhtmltopdf/[Operating System Name]/wkhtmltopdf``` para alterar as permissões do arquivo.  
Além disso, como o processo de compilação copia os arquivos executáveis para uma pasta com o nome do sistema operacional, é necessário executar o comando ```umask 0022``` para garantir que o executável copiado mantenha as permissões corretas.

Se você estiver desenvolvendo em uma máquina com Windows, é necessário executar o Visual Studio no modo Administrador.  
Em alguns casos, será necessário realizar as seguintes etapas:
- Clique com o botão direito no arquivo `./wkhtmltopdf/Windows/wkhtmltopdf.exe`
- Vá em "Propriedades" e clique na aba "Compatibilidade"
- Em seguida, clique em "Alterar configurações para todos os usuários"
- Marque a opção "Executar este programa como administrador".