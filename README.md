# Vending Machine

This is a .NET Core API solution (VendingAPI) and an Angular Application (VendingApp) that together simulate a virtual Vending Machine.

### Prerequisites

VendingAPI needs Visual Studio and .Net Core 3.1

VendingApp needs Node.js, npm, Angular 9.1.3 and a browser like Google Chrome.

### Running VendingAPI

Run: 
  - Open the solution with Visual Studio.
  - Press <kbd>F5</kbd> in Visual Studio.

It will be executed on: https://localhost:5001/api/

### Installing and running VendingApp

In the directory where VendingApp is stored.

Install:
```
$ npm install
```

Run:
```
$ ng serve -o
```

It will open a new page: http://localhost:4200/

## Improvements:

* Split VendingAPI solution in several projects, decouple the layers and make easier the solution grows.
* Merge ApiModels of the same entities and include Data Annotations in VendingAPI solution.
* Creating unit tests in VendingAPI and VendingApp. Mock data.

## Authors

* **Pedro Calero** - *Initial work* - (https://github.com/pcalero/)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
