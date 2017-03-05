var app = angular.module('ageRangerApp', ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "personController",
        templateUrl: "/app/views/personView.html"
    });

    $routeProvider.when("/person/add", {
        controller: "personController",
        templateUrl: "/app/views/personAddView.html"
    });

    $routeProvider.when("/person/add/:id", {
        controller: "personController",
        templateUrl: "/app/views/personEditView.html"
    });

    $routeProvider.otherwise({ reirectTo: "/" });
});