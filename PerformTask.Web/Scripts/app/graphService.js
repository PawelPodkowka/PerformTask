app.service('GraphService', function($http) {

    this.getNodes = function() {
        return $http.get("api/nodes");
    };

    this.getShortestPath = function(start, end) {
        var config = {
            params: {
                start: start,
                end: end
            }
        }

        return $http.get("api/graphpath", config);
    };
});