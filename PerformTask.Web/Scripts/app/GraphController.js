app.controller('GraphController', function ($scope, $location, GraphService) {
    $scope.isLoading = false;
    $scope.isFindPossible = false;
    var selectedNodes;
    loadGraph();

    function loadGraph() {
        $scope.isLoading = true;
        GraphService.getNodes()
                          .success(function (result) {
                              $scope.graph = {
                                  data: {
                                      nodes: result.nodes,
                                      edges: result.edges
                                  },
                                  options: {
                                      "width": "100%",
                                      "height": "80%",
                                      interaction: {
                                          multiselect: true,
                                          selectable: true,
                                          selectConnectedEdges: false,
                                          hoverConnectedEdges: false
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

    $scope.findPath = function () {
        if (selectedNodes && $scope.isFindPossible) {
            var start = selectedNodes[0];
            var end = selectedNodes[1];
            GraphService.getShortestPath(start, end)
                .success(function(result) {
                    $scope.bestPath = result;
                })
                .error(function(reason) {
                    console.error('Uuups :( I can not find best path ' + reason);
                });
        }
    }

    $scope.selectNode = function (params) {
        $scope.isFindPossible = params.nodes.length === 2;
        selectedNodes = $scope.isFindPossible ? params.nodes : null;
        $scope.$apply();
    }
});