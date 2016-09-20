app.controller('GraphController', function ($scope, $location, GraphService) {
    $scope.isLoading = false;

    loadGraph();

    function loadGraph() {
        $scope.isLoading = true;
        GraphService.getNodes()
                          .success(function (result) {
                              $scope.Nodes = result;
                          })
                          .error(function (reason) {
                              console.error('Uuups :( I can not get graph nodes because: ' + reason);
                          })
                          .finally(function () {
                              $scope.isLoading = false;
                          });
    };
});