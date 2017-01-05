function MapController(siteUrl) {
    var self = this;
    self.controllerUrl = siteUrl;

    self.getCompanyDetailsById = function (data, successFun, failFun) {

        $.ajax({
            url: self.controllerUrl,
            cache: false,
            type: "get",
            dataType: "json",
            data: {
                id: JSON.stringify(data)
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