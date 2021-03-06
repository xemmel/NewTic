﻿$(function () {
  $(".dp").datepicker({ dateFormat: 'M d, yy' });
});


var app = angular.module("customerApp", ['ui.bootstrap']);

//var customerCtrl = function($scope, $http) {
app.controller("customerCtrl", function ($scope, $http) {

 

  $scope.customerFilter = "";
  $scope.customer = {};
  $scope.editMode = false;
  $scope.loadMode = false;

  $scope.subscriptions = [];
  $scope.sub = {};

  $http({ method: "GET", url: "/api/SubscriptionApi" }).
    success(function (data) {
      $scope.subscriptions = data;
      $scope.sub = $scope.subscriptions[0];
      console.dir($scope.subscriptions);
    });

  $scope.x = "Clara";
  var restUrl = "/api/CustomerApi";


  $scope.submit = function () {
    // console.dir($scope.customer);
    $scope.customer.CustomerType = $scope.sub.SubscriptionId;
    $http({ method: "POST", url: restUrl, data: $scope.customer })
      .success(function (data) {
        //console.log("Success data: " + data);
        $scope.updateList();
        $scope.customer = {};
      }).
    error(function (data) {
      console.log("Error data: " + data);

    });
  }; //End submit


  $scope.customerList = [];

  $scope.updateList = function () {
    $scope.loadMode = true;
    $http({ method: "GET", url: restUrl }).
      success(function (data) {
        console.dir(data);
        $scope.customerList = data;
        $scope.loadMode = false;

      }).
      error(function (data) {
        $scope.loadMode = false;

      });
  }; //End updateList

  $scope.delete = function (id) {
    //console.log(id);
    $http({ method: "DELETE", url: restUrl + "/" + id }).
      success(function (data) {
        //console.log("dele Success data: " + data);
        $scope.updateList();


      })
      .error(function (data) {
        console.log("dele Error data: " + data);

      });
  }; //end delete

  function getSubscriptionIndex(id) {
    for (i = 0; i < $scope.subscriptions.length; i++) {
      if ($scope.subscriptions[i].SubscriptionId == id) {
        return i;
      }
    }
  }
  
  $scope.getSubName = function(id)
  {
    for (i = 0; i < $scope.subscriptions.length; i++) {
      if ($scope.subscriptions[i].SubscriptionId == id) {
        return $scope.subscriptions[i].Name;
      }
    }

  }

  $scope.edit = function (cust) {
    var subId = cust.CustomerType;
    console.log("SubId: " + subId);
    var index = getSubscriptionIndex(subId);
    console.log("Index: " + index);

    //console.log(getSubscriptionIndex());
    $scope.sub = $scope.subscriptions[index];
    $scope.customer = cust;
    $scope.editMode = true;
  }; //end edit

  $scope.update = function () {
    //console.dir($scope.customer);
    $scope.customer.CustomerType = $scope.sub.SubscriptionId;
    $http({ method: "PUT", url: restUrl + "/" + $scope.customer.CustomerId, data: $scope.customer }).
      success(function (data) {
        console.log("SUC" + data);
        $scope.editMode = false;
        $scope.updateList();
        $scope.customer = {};
        $scope.sub = $scope.subscriptions[0];

      }).
      error(function (date) { });
  };


  $scope.cancelUpdate = function () {
    $scope.customer = {};
    $scope.editMode = false;
    $scope.updateList();
    $scope.sub = $scope.subscriptions[0];

  };

  $scope.resetSearch = function () {
    // console.log("reset");
    $scope.customerFilter = "";
  };
  $scope.updateList();

  //Date functions

  $scope.fromOpened = false;
  $scope.to = false;

  $scope.fromOpen = function ($event) {
    $event.preventDefault();
    $event.stopPropagation();

    $scope.fromOpened = true;
  };

  $scope.toOpen = function ($event) {
    $event.preventDefault();
    $event.stopPropagation();

    $scope.toOpened = true;
  };

  $scope.dateOptions = {
    formatYear: 'yy',
    startingDay: 1
  };
  $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate', 'mediumDate'];
  $scope.format = $scope.formats[4];
});