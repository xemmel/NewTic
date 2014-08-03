var app = angular.module('symbolMod', ['ngResource']);

app.factory('getRest', function ($resource) {
  return $resource('../api/SymbolApi/:id', { id: '@SymbolId' }, {update: { method: 'PUT' }});
});



var sCtrl = function($scope, getRest) {
  $scope.symbols = [];
  $scope.symbol = {};
  $scope.updateMode = false;
  $scope.status = "";
  $scope.updateGrid = function () {
    $scope.symbols = getRest.query();
  };

  //Save(Post)/create
  $scope.create = function () {
    //console.dir($scope.symbol);
    getRest.save($scope.symbol).$promise.then(function (data) {
      //console.dir(data);
      $scope.status = "Symbol '" + data.Name + "' created with Id: " + data.SymbolId;
      $scope.symbol = {};
      $scope.updateGrid();
    }, function (error) {
      $scope.status = error.data.ExceptionMessage;
    });
  };

  //Edit
  $scope.edit = function () {
    var id = this.symbol.SymbolId;
    $scope.updateMode = true;
    $scope.symbol = this.symbol;
  };

  $scope.cancelEdit = function () {
    $scope.symbol = {};
    $scope.updateMode = false;
    $scope.updateGrid();
  };

  //update/PUT
  $scope.update = function () {
   
    getRest.update({ id: $scope.symbol.SymbolId }, $scope.symbol).$promise.then(function (data) {
      $scope.cancelEdit();
      $scope.status = "Symbol '" + data.Name + "' updated with Id: " + data.SymbolId;
  
    }, function (error) {
      $scope.status = error.data.ExceptionMessage;

    });;
  };


  // Delete(Delete)
  $scope.delete = function () {
    var id = this.symbol.SymbolId;
    getRest.delete({ id: id }).$promise.then(function (data) {
      $scope.updateGrid();
      $scope.status = "Symbol deleted..";

    }, function (error) {
      console.log("Error on delete(delete)");
      console.dir(error);
      $scope.status = error.data.ExceptionMessage;

    });
  };

  $scope.updateGrid();
  //$scope.s = getRest.get({ id: 3 });
  //console.dir($scope.s);
};