# The Dot Net Info

Simple client-side application that displays .NET news titles from other blogs. The Dot Net Info does not show any content from the original author. It displays only title, published date and author name. Since it is only a client-side app if the author has CORS policy it set up it could not be displayed.

### This application is heavily inspired by [discoverdot.net](https://discoverdot.net/)

## Installation 

### Dotnet

The only prerequisite is having .NET 6 SDK.

1. Clone or download the project
2. Run

### Built With

* Blazor Web Assembly
* .NET 6
* [Fluxor](https://github.com/mrpmorris/Fluxor)

### Configs

You can override any of the configs by changing them in appSettings.json or through environment variables.

| Parameter  | Default Value | Description |
| ------------- | ------------- |------------- |
| Posts Count| 20  | How many posts to fetch in order to display. |
| Cache Duration In Hours  |  1  | How long to store the information before making another request to the blogs. |
| Blogs  | hasan-hasanov's Blog, Scott Hanselman's Blog | Blogs to fetch information from. The blog should have CORS policy to set to all. |

## Meta

* Hasan Hasanov – [@hmhasanov](https://twitter.com/hmhasanov)
* Blog - [Hasan Hasanov](https://hasan-hasanov.com/)

## Contributing

1. Fork it (<https://github.com/yourname/yourproject/fork>)
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new Pull Request
