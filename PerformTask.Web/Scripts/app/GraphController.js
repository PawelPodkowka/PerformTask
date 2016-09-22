app.controller('GraphController', function ($scope, $location, GraphService) {
    $scope.isLoading = false;

    loadGraph();

    function loadGraph() {
        $scope.isLoading = true;
        GraphService.getNodes()
                          .success(function (result) {
                              data: {
                                  $scope.graph = {
                                      nodes: result.nodes,
                                      edges: result.edges,
                                      options: {
                                          "width": "100%",
                                          "height": "80%"
                                      }
                                  }
                              }
                          })
                          .error(function (reason) {
                              console.error('Uuups :( I can not get graph nodes because: ' + reason);
                          })
                          .finally(function () {
                              $scope.isLoading = false;
                          });
    };
});