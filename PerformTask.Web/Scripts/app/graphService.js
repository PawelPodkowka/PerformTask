app.service('GraphService', function($http) {

    this.getNodes = function() {
        return $http.get("http://localhost:54718/api/nodes");
    };

    this.getShortestPath = function(start, end) {
        var config = {
            params: {
                start: start,
                end: end
            }
        }

        return $http.get("http://localhost:54718/api/graphpath", config);
    };
});