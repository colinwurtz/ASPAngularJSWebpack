import angular from 'angular';
import {User} from './user';
//import * as User from './user';
var app = angular.module('app', []);

app.controller('mainCtrl', ($scope: any) => {
    let colin = new User("Colin!!!");

    colin.name = 'Colin!';
    colin.address = 'USA';
    let message = colin.sayHello();

    $scope.user = colin;
    $scope.message = message;


});
