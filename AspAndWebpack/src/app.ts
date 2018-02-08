import angular from 'angular';
//import * as uib from "angular-ui-bootstrap";
//import * as ngAnimate from "angular-animate";

//import * as ngTouch from "angular-touch";
//import * as xeditable from "angular-xeditable";
//import * as ngSanitize from "angular-sanitize";
//import * as sortable from "angular-ui-sortable";
//import * as toaster from "angularjs-toaster";
//import "angular-ui-bootstrap/dist/ui-bootstrap-tpls.js";
//import accordion from "angular-ui-bootstrap/src/accordion";
//import toaster from "angularjs-toaster";

import { User } from './user';
//import {toaster} from "angularjs-toaster";
//import * as User from './user';
import { GroceryModel } from './GroceryModel';
//import { ToasterInter} from "./toasterInterface";
let app = angular.module('app', ['ui.bootstrap', 'xeditable','toaster']); //'ngAnimate', 'ngTouch', 'xeditable', 'ngSanitize', 'ui.select', 'ui.sortable', 'toaster'

app.run(['editableOptions', editableOptions => {
    editableOptions.theme = 'bs3';
    editableOptions.activate = 'select';
    editableOptions.defaultValue = 'Unknown';
}]);


app.controller('mainCtrl', ($scope: any, toaster:any) => {
    let colin:User = new User("Colin!!!");
    let groceryList: Array<GroceryModel> = [];

    const groc1 = new GroceryModel();
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
    $scope.options = ['op1', 'anotherop'];
    $scope.user = colin;
    $scope.message = message;

    $scope.oneAtATime = true;

    $scope.states = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California', 'Colorado', 'Connecticut', 'Delaware', 'Florida', 'Georgia', 'Hawaii', 'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana', 'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota', 'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire', 'New Jersey', 'New Mexico', 'New York', 'North Dakota', 'North Carolina', 'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island', 'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont', 'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'];
    $scope.items = ['Item 1', 'Item 2', 'Item 3'];

    $scope.addItem = function () {
        var newItemNo = $scope.items.length + 1;
        $scope.items.push('Item ' + newItemNo);
    };

    $scope.status = {
        isFirstOpen: true,
        isFirstDisabled: false
    };
    $scope.user1 = {
        name: 'awesome user'
    };

    $scope.waitMessage = {
        text: "Waiting..."
    };

    $scope.datar = {
        stuff: "show me some big stuff!"
    }

    $scope.pop = () => {
        debugger;
        toaster.pop('info', "title", "text"); //works
    };
});

app.directive('waitInfo', () => {
    console.log("loading up wait info directive!");
    return {
        templateUrl: '/src/waitInfo.html',
        restrict: "E",
        scope: {
            message: '=' //telling our directive it should expect a user object
        }
    }
});