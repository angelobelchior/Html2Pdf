// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the Html2Pdf.Lib
// https://github.com/angelobelchior/Html2Pdf
// ***************************************************************************************

using System;
using Html2PdfLib;
using Microsoft.Extensions.Logging;

Console.WriteLine("Html2PdfLib Playground");

//log provider
ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Debug);
});
ILogger logger = factory.CreateLogger("Program");

var html =
    """
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>HTML to PDF Test</title>
        <style>
            body {
                font-family: Arial, sans-serif;
                margin: 0;
                padding: 0;
                background-color: #f0f8ff;
            }
            header {
                background-color: #ff7f50;
                color: white;
                text-align: center;
                padding: 20px;
            }
            nav {
                display: flex;
                justify-content: space-around;
                background-color: #4682b4;
                padding: 10px;
            }
            nav a {
                color: white;
                text-decoration: none;
            }
            section {
                padding: 20px;
                display: flex;
                flex-wrap: wrap;
                gap: 20px;
                background-color: #f5f5f5;
            }
            article {
                background-color: #ffefd5;
                border: 2px solid #deb887;
                padding: 15px;
                flex: 1 1 calc(33.33% - 40px);
                box-shadow: 2px 2px 5px rgba(0,0,0,0.3);
            }
            footer {
                text-align: center;
                background-color: #2e8b57;
                color: white;
                padding: 10px;
            }
            .base64-image {
                width: 100%;
                max-width: 300px;
                display: block;
                margin: 0 auto;
            }
            .color-box {
                width: 100px;
                height: 100px;
                display: inline-block;
                margin: 5px;
            }
            form {
                background-color: #e6e6fa;
                padding: 20px;
                margin: 20px 0;
                border: 2px solid #8a2be2;
                border-radius: 10px;
            }
            form label {
                display: block;
                margin: 10px 0 5px;
            }
            form input, form textarea, form select, form button {
                width: 100%;
                padding: 10px;
                margin-bottom: 10px;
                border: 1px solid #ccc;
                border-radius: 5px;
            }
            tr { 
                page-break-inside: avoid; 
            }
        </style>
    </head>
    <body>
        <header>
            <h1>Test HTML to PDF Conversion</h1>
            <p>A page with diverse elements to test your tool</p>
        </header>
        <nav>
            <a href="https://www.microsoft.com">Microsoft</a>
            <a href="https://www.google.com">Google</a>
            <a href="file:./myfile.txt</a>
        </nav>
        <section>
            <article>
                <h2>Article 1</h2>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque facilisis.</p>
                <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/w8AAn8C4iO5fwAAAABJRU5ErkJggg==" alt="Black dot" class="base64-image">
            </article>
            <article>
                <h2>Article 2</h2>
                <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==" alt="Blue square" class="base64-image">
            </article>
            <article>
                <h2>Article 3</h2>
                <p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
                <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/w8AAn8C4iO5fwAAAABJRU5ErkJggg==" alt="Black dot" class="base64-image">
            </article>
            <article>
            <h2>Article 4</h2>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque facilisis.</p>
                <img src="https://via.placeholder.com/100" alt="Placeholder Image" class="base64-image">
            </article>
        </section>
        <section>
            <h2>Colors</h2>
            <div class="color-box" style="background-color: red;"></div>
            <div class="color-box" style="background-color: green;"></div>
            <div class="color-box" style="background-color: blue;"></div>
            <div class="color-box" style="background-color: yellow;"></div>
            <div class="color-box" style="background-color: purple;"></div>
        </section>
        <section>
            <h2>Feedback Form</h2>
            <form action="#" method="post">
                <label for="name">Name:</label>
                <input type="text" id="name" name="name" placeholder="Enter your name">
    
                <label for="email">Email:</label>
                <input type="text" id="email" name="email" placeholder="Enter your email">
    
                <label for="message">Message:</label>
                <textarea id="message" name="message" rows="5" placeholder="Your message..."></textarea>
    
                <label for="rating">Rating:</label>
                <select id="rating" name="rating">
                    <option value="excellent">Excellent</option>
                    <option value="good">Good</option>
                    <option value="average">Average</option>
                    <option value="poor">Poor</option>
                </select>
    
                <button type="submit">Submit</button>
            </form>
        </section>
        
    <br />
    
        <pre>
                             40m     41m     42m     43m     44m     45m     46m     47m
                    <span style="">  gYw  </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; background-color: white; ">  gYw  </span>
            <span style="">    1m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; ">  gYw   </span><span style="font-weight: bold; "></span><span style="font-weight: bold; background-color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; "></span><span style="font-weight: bold; background-color: white; ">  gYw  </span>
            <span style="">   30m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; ">  gYw   </span><span style="color: dimgray; "></span><span style="background-color: dimgray; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: red; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: lime; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: yellow; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: #3333FF; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: fuchsia; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: aqua; color: dimgray; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="background-color: white; color: dimgray; ">  gYw  </span>
            <span style=""> 1;30m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; ">  gYw   </span><span style="font-weight: bold; color: dimgray; "></span><span style="font-weight: bold; background-color: dimgray; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: red; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: lime; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: yellow; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: #3333FF; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: fuchsia; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: aqua; color: dimgray; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: dimgray; "></span><span style="font-weight: bold; background-color: white; color: dimgray; ">  gYw  </span>
            <span style="">   31m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; ">  gYw   </span><span style="color: red; "></span><span style="background-color: dimgray; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: red; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: lime; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: yellow; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: #3333FF; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: fuchsia; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: aqua; color: red; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="background-color: white; color: red; ">  gYw  </span>
            <span style=""> 1;31m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; ">  gYw   </span><span style="font-weight: bold; color: red; "></span><span style="font-weight: bold; background-color: dimgray; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: red; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: lime; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: yellow; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: #3333FF; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: fuchsia; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: aqua; color: red; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: red; "></span><span style="font-weight: bold; background-color: white; color: red; ">  gYw  </span>
            <span style="">   32m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; ">  gYw   </span><span style="color: lime; "></span><span style="background-color: dimgray; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: red; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: lime; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: yellow; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: #3333FF; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: fuchsia; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: aqua; color: lime; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="background-color: white; color: lime; ">  gYw  </span>
            <span style=""> 1;32m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; ">  gYw   </span><span style="font-weight: bold; color: lime; "></span><span style="font-weight: bold; background-color: dimgray; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: red; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: lime; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: yellow; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: #3333FF; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: fuchsia; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: aqua; color: lime; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: lime; "></span><span style="font-weight: bold; background-color: white; color: lime; ">  gYw  </span>
            <span style="">   33m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; ">  gYw   </span><span style="color: yellow; "></span><span style="background-color: dimgray; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: red; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: lime; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: yellow; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: #3333FF; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: fuchsia; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: aqua; color: yellow; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="background-color: white; color: yellow; ">  gYw  </span>
            <span style=""> 1;33m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; ">  gYw   </span><span style="font-weight: bold; color: yellow; "></span><span style="font-weight: bold; background-color: dimgray; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: red; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: lime; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: yellow; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: #3333FF; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: fuchsia; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: aqua; color: yellow; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: yellow; "></span><span style="font-weight: bold; background-color: white; color: yellow; ">  gYw  </span>
            <span style="">   34m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; ">  gYw   </span><span style="color: #3333FF; "></span><span style="background-color: dimgray; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: red; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: lime; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: yellow; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: #3333FF; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: fuchsia; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: aqua; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="background-color: white; color: #3333FF; ">  gYw  </span>
            <span style=""> 1;34m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; ">  gYw   </span><span style="font-weight: bold; color: #3333FF; "></span><span style="font-weight: bold; background-color: dimgray; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: red; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: lime; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: yellow; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: #3333FF; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: fuchsia; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: aqua; color: #3333FF; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: #3333FF; "></span><span style="font-weight: bold; background-color: white; color: #3333FF; ">  gYw  </span>
            <span style="">   35m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; ">  gYw   </span><span style="color: fuchsia; "></span><span style="background-color: dimgray; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: red; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: lime; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: yellow; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: #3333FF; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: fuchsia; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: aqua; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="background-color: white; color: fuchsia; ">  gYw  </span>
            <span style=""> 1;35m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; ">  gYw   </span><span style="font-weight: bold; color: fuchsia; "></span><span style="font-weight: bold; background-color: dimgray; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: red; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: lime; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: yellow; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: #3333FF; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: fuchsia; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: aqua; color: fuchsia; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: fuchsia; "></span><span style="font-weight: bold; background-color: white; color: fuchsia; ">  gYw  </span>
            <span style="">   36m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; ">  gYw   </span><span style="color: aqua; "></span><span style="background-color: dimgray; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: red; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: lime; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: yellow; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: #3333FF; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: fuchsia; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: aqua; color: aqua; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="background-color: white; color: aqua; ">  gYw  </span>
            <span style=""> 1;36m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; ">  gYw   </span><span style="font-weight: bold; color: aqua; "></span><span style="font-weight: bold; background-color: dimgray; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: red; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: lime; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: yellow; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: #3333FF; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: fuchsia; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: aqua; color: aqua; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: aqua; "></span><span style="font-weight: bold; background-color: white; color: aqua; ">  gYw  </span>
            <span style="">   37m </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; ">  gYw   </span><span style="color: white; "></span><span style="background-color: dimgray; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: red; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: lime; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: yellow; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: #3333FF; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: fuchsia; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: aqua; color: white; ">  gYw  </span><span style=""> </span><span style="background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="background-color: white; color: white; ">  gYw  </span>
            <span style=""> 1;37m </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; ">  gYw   </span><span style="font-weight: bold; color: white; "></span><span style="font-weight: bold; background-color: dimgray; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: red; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: lime; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: yellow; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: #3333FF; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: fuchsia; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: aqua; color: white; ">  gYw  </span><span style=""> </span><span style="font-weight: bold; background-color: initial; color: initial; font-weight: normal; opacity: 1.0; font-style: normal; text-decoration: none; display: inline; color: white; "></span><span style="font-weight: bold; background-color: white; color: white; ">  gYw  </span>
        </pre>
        
        <footer>
            <p>&copy; 2024 HTML to PDF Test Page</p>
        </footer>
    </body>
    </html>
    """;

var pathToSamples = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

//convert to file PDF and return bytes from pdf 
var resutHtml = await Html2Pdf
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
        })
    .FromHtml(html)
    .Logger(logger)
    .TimeoutConvert(30000)
    .IgnoreImageErrors(true)
    .LogArgumentsInfoLevel(true)
    .SaveToAsync(Path.Combine(pathToSamples,"html2pdfHtml.pdf"), true /*return bytes*/, CancellationToken.None);

var elpt = resutHtml.Elapsedtime;

if (resutHtml.IsSuccess)
{
    var bytes = resutHtml.Content;
    var file = resutHtml.FileName;
}
else
{
    var err = resutHtml.Error;
}

//convert to bytes PDF
resutHtml = await Html2Pdf
    .Config((opt) =>
    {
        opt.Title("This is a sample PDF document")
         .Replace("HTML to PDF Test Page", "HTML to PDF Test Page - Sample 1")
         .HeaderText("Header Text Sample 1", TextAlignment.Center)
         .HeaderFont("Verdana", 15)
         .FooterText("Footer Text Sample 1", TextAlignment.Center)
         .FooterFont("Verdana", 15)
         .FooterSpacing(23)
         .PageMargins(10);
    })
    .FromHtml(html)
    .Logger(logger)
    .TimeoutConvert(30000)
    .RunAsync(CancellationToken.None);

elpt = resutHtml.Elapsedtime;

if (resutHtml.IsSuccess)
{
    var bytes = resutHtml.Content;
    var file = resutHtml.FileName; //null value
}
else
{
    var err = resutHtml.Error;
}

//convert Site page to file PDF and return bytes from pdf 
var resutUrl = await Html2Pdf
    .Config((opt) =>
    {
        opt.PageMargins(5);
    })
    .FromUrl(new Uri("https://en.wikipedia.org/wiki/C_Sharp_(programming_language)"))
    .Logger(logger)
    .TimeoutConvert(10000)
    .SaveToAsync($"{pathToSamples}/html2pdfUrl.pdf", true /*return bytes*/, CancellationToken.None);

elpt = resutUrl.Elapsedtime;

if (resutUrl.IsSuccess)
{
    var bytes = resutUrl.Content;
    var file = resutUrl.FileName;
}
else
{
    var err = resutUrl.Error;
}

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

var order1 = new Order("Roberto Rivellino", "Rua S&atilde;o Jorge, 777", "+55 11 912345678", [
    new("Product 1", 9.99m),
    new("Product 2", 19.99m),
    new("Product 3", 29.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
    new("Product 4", 39.99m),
]);

//convert Razor page to file PDF and return bytes from pdf 
var resutRazor = await Html2Pdf
    .Config((opt) =>
    {
        opt.PageMargins(5);
    })
    .FromRazorTemplate(razorTemplate,order1)
    .Logger(logger)
    .TimeoutConvert(10000)
    .SaveToAsync(Path.Combine(pathToSamples,"html2pdfRazorTemplate.pdf"), true /*return bytes*/);

elpt = resutRazor.Elapsedtime;

if (resutRazor.IsSuccess)
{
    var bytes = resutRazor.Content;
    var file = resutRazor.FileName;
}
else
{
    var err = resutRazor.Error;
}

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

//Convert Razor page using an order list in parallel tasks to archive PDF and return PDF bytes
var lsttask = new List<Task<Html2PdfResult>>();
for (int i = 0; i < lstrorder.Count; i++)
{
   lsttask.Add(Html2Pdf
        .Config((opt) =>
        {
            opt.PageMargins(5);
        })
        .FromRazorTemplate(razorTemplate, lstrorder.ElementAt(i))
        .Logger(logger)
        .TimeoutConvert(10000)
        .SaveToAsync(Path.Combine(pathToSamples, $"html2pdfRazorTemplate{i+1}.pdf"), true /*return bytes*/, CancellationToken.None));
}
Task.WhenAll(lsttask).Wait();

foreach (var task in lsttask)
{

    elpt = task.Result.Elapsedtime;
    if (task.Result.IsSuccess)
    {
        var bytes = task.Result.Content;
        var file = task.Result.FileName;
    }
    else
    {
        var err = task.Result.Error;
    }
}

public record Product(string Name, decimal Price);
public record Order(string CustomerName, string CustomerAddress, string CustomerPhoneNumber, List<Product> Products);