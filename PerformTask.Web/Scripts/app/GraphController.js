app.controller('GraphController', function ($scope, $location, GraphService) {
    $scope.isLoading = false;
    $scope.showFindButton = true;
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

    function markPath(item, index) {
        $scope.bestPath.some(function(connection) {
            if ((connection.from == item.from && connection.to == item.to)
                || (connection.to == item.from && connection.from == item.to)) {
                item.color = '#73F700';
                item.value = 3;
            }
        });
    }

    $scope.findPath = function () {
        if (selectedNodes) {
            var start = selectedNodes[0];
            var end = selectedNodes[1];
            GraphService.getShortestPath(start, end)
                              .success(function (result) {
                                  $scope.bestPath = result;
                                 // $scope.graph.data.edges.forEach(markPath);
                              })
                              .error(function (reason) {
                                  console.error('Uuups :( I can not find best path ' + reason);
                              })
                              .finally(function () {
                                  $scope.isLoading = false;
                              });
        }
    }

    $scope.selectNode = function (params) {
        $scope.showFindButton = params.nodes.length == 2;
        selectedNodes = $scope.showFindButton ? params.nodes : null;
    }
});