﻿var app = angular.module('PawelPodkowkaTask', ["ngRoute", "ngAnimate", "ang.mod.visgraph"]);


app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider.when('/',
                       {
                           templateUrl: 'Graph/Show',
                           controller: 'GraphController'
                       })
                   .otherwise(
                       {
                           redirectTo: '/'
                       });

    $locationProvider.hasPrefix = '!';
    $locationProvider.html5Mode = true;
}]);