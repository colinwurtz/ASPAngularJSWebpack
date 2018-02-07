import angular from 'angular';

angular.module('app').directive('bigDirective', () => {
    console.log("loading up big Directive directive!");
    return {
        templateUrl: '/src/bigDirective.html',
        restrict: "E",
        scope: {
            data: '=' //telling our directive it should expect a user object
        }
    }
});