import angular from 'angular';
import {User} from './user';
//import * as User from './user';
import {GroceryModel} from './GroceryModel';
var app = angular.module('app', []);


app.controller('mainCtrl', ($scope: any) => {
    let colin = new User("Colin!!!");
    let groceryList: Array<GroceryModel> = [];

    const groc1: GroceryModel = new GroceryModel();
    groc1.groceryName = 'Asparagus';
    groc1.groceryStoreLocations.push('Aisle1');
    groc1.groceryStoreLocations.push('Aisle2');

    const groc2: GroceryModel = new GroceryModel();
    groc2.groceryName = 'Onion';
    groc2.groceryStoreLocations.push('Produce');
    groc2.groceryStoreLocations.push('Cold');

    groceryList.push(groc1, groc2);


    colin.name = 'Colin!';
    colin.address = 'USA';
    let message = colin.sayHello();

    $scope.grocList = groceryList;

    $scope.user = colin;
    $scope.message = message;


});
