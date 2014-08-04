var app = angular.module('symbolMod', ['ngResource']);

app.factory('getRest', function ($resource) {
  return $resource('../api/SymbolApi/:id', { id: '@SymbolId' }, {update: { method: 'PUT' }});
});



var sCtrl = function($scope, getRest) {
  $scope.symbols = [];
  $scope.loadMode = false;
  $scope.symbol = {};
  $scope.updateMode = false;
  $scope.status = "";

  $scope.updateGrid = function () {
    //console.log("update");
    $scope.loadMode = true; 
    getRest.query()
    .$promise.then(function (data) {
      $scope.symbols = data;
      $scope.loadMode = false; 
    }, function (error) {
      $scope.loadMode = false;
      $scope.status = error.data.ExceptionMessage;

    });
  };

  //Save(Post)/create
  $scope.create = function () {
    //console.dir($scope.symbol);
    $scope.loadMode = true;
    getRest.save($scope.symbol).$promise.then(function (data) {
      //console.dir(data);
      $scope.status = "Symbol '" + data.Name + "' created with Id: " + data.SymbolId;
      $scope.symbol = {};
      $scope.updateGrid();
    }, function (error) {
      $scope.loadMode = false;
      $scope.status = error.data.ExceptionMessage;
    });
  };

  //Edit
  $scope.edit = function () {
    $scope.loadMode = true;

    var id = this.symbol.SymbolId;
    $scope.updateMode = true;
    $scope.symbol = this.symbol;
    $scope.loadMode = false;

  };

  $scope.cancelEdit = function () {
    $scope.loadMode = true;
    $scope.symbol = {};
    $scope.updateMode = false;
    $scope.updateGrid();
  };

  //update/PUT
  $scope.update = function () {
    $scope.loadMode = true;
    getRest.update({ id: $scope.symbol.SymbolId }, $scope.symbol).$promise.then(function (data) {
      $scope.cancelEdit();
      $scope.status = "Symbol '" + data.Name + "' updated with Id: " + data.SymbolId;
      $scope.loadMode = false;

  
    }, function (error) {
      $scope.loadMode = false;

      $scope.status = error.data.ExceptionMessage;

    });;
  };


  // Delete(Delete)
  $scope.delete = function () {
    $scope.loadMode = true;

    var id = this.symbol.SymbolId;
    getRest.delete({ id: id }).$promise.then(function (data) {
      $scope.status = "Symbol deleted..";
      $scope.updateGrid();

    }, function (error) {
      console.log("Error on delete(delete)");
      console.dir(error);
      $scope.status = error.data.ExceptionMessage;
      $scope.loadMode = false;
    });
  };

  $scope.updateGrid();
  //$scope.s = getRest.get({ id: 3 });
  //console.dir($scope.s);
};