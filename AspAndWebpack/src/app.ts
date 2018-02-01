import angular from 'angular';
debugger;
var app = angular.module('app', []);

app.controller('mainCtrl', ($scope: any) => {
    debugger;
    console.log('inside app controller');
    console.log($scope.filterOptions);
    $scope.user3 = {
        name: 'Emily',
        address: 'Prairie Village',
        state: 'KS'
    }

    $scope.user = {
        name: 'Colin',
        address: 'Prairie Village',
        state: 'Kansas'
    }

    $scope.user2 = {
        name: 'Luke Skywalker',
        address: 'Outer Space',
        state: 'Secret Rebel Base'
    }

    $scope.filterOptions = {
        names: ["Option1", "Option2", "Options3"]
    }

});
