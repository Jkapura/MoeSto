function MapController(siteUrl) {
    var self = this;
    self.controllerUrl = siteUrl;

    self.getObjectsByBounds = function (bounds, successFun, failFun) {

        $.ajax({
            url: self.controllerUrl,
            cache: false,
            type: "get",
            dataType: "json",
            data: {
                bounds: JSON.stringify(bounds)
            },
            success: function (result) {
                successFun(result);
            },
            error: function (result) {
                failFun(result);
            }
        });

    };
    return self;
};