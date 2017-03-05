'use strict';
app.controller("personController", function ($scope, $http, $routeParams) {

    $scope.id = $routeParams.id;
    $scope.persons = [];
    $scope.person = null;
    $scope.search_criteria = null;
    $scope.post_data_response = null;

    $scope.isBusy = true;
    $scope.isResultFound = true;

    $scope.init = function () {
        get_persons();
    };

    $scope.initEdit = function () {
        get_person();
    };

    $scope.initNew = function () {
        clear_form();
    };

    $scope.search = function () {
        get_persons();
    };

    
    function clear_form() {
        $scope.person.id = null;
        $scope.person.firstName = null;
        $scope.person.lastName = null;
        $scope.person.age = null;
    };

    function get_persons() {
        var _params = $scope.search_criteria ? $scope.search_criteria : 'null';

        $http.get("api/person/" + _params)
        .then(function (result) {
            // Success
            angular.copy(result.data, $scope.persons);
        },
        function () {
            // Error
            // alert('error');
        })
        .then(function () {
            // Finally
            $scope.isBusy = false;
            $scope.isResultFound = $scope.persons.length > 0;
        });
    };

    function get_person() {
        $http.get("api/person/getbyid/" + $scope.id)
        .then(function (result) {
            // Success
            $scope.person = result.data;
        },
        function () {
            // Error
            alert('error');
        })
        .then(function () {
            // Finally
            $scope.isBusy = false;
            $scope.isResultFound = $scope.persons.length > 0;
        });
    };

    $scope.addPerson = function (isValid) {
        if (isValid) {
            var data = {
                id: 0,
                firstName: $scope.person.firstName,
                lastName: $scope.person.lastName,
                age: $scope.person.age
            };

            $.ajax({
                url: '/api/person/add',
                type: 'POST',
                data: data,
                ContentType: 'application/json;utf-8',
                datatype: 'json'
            }).done(function (resp) {
                clear_form();                
                alert('Success');
            }).error(function (err) {
                alert("Error " + err.status);
            });
        }
        else {
            alert('Validation Error');
        }
    };

    $scope.editPerson = function (isValid) {

        if (isValid) {
            var data = {
                id: $scope.person.id,
                firstName: $scope.person.firstName,
                lastName: $scope.person.lastName,
                age: $scope.person.age
            };

            $.ajax({
                url: '/api/person/add',
                type: 'POST',
                data: data,
                ContentType: 'application/json;utf-8',
                datatype: 'json'
            }).done(function (resp) {
                alert('Success');
            }).error(function (err) {
                alert("Error " + err.status);
            });
        }
        else {
            alert('Validation Error');
        }
    };

});