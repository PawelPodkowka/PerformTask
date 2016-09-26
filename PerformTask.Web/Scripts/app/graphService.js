app.service('GraphService', function($http) {

    var apiAddress = "http://localhost:54718/api/";

    this.getNodes = function() {
        return $http.get(apiAddress + "nodes");
    };

    this.getShortestPath = function(start, end) {
        var config = {
            params: {
                start: start,
                end: end
            }
        }

        return $http.get(apiAddress + "graphpath", config);
    };
});