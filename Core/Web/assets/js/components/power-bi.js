import * as powerBiClient from 'powerbi-client'

window.PowerBi = {
    Bootstrap: function (container, type) {
        const config = {
            type: type,
            hostname: 'https://app.powerbi.com'
        }

        window.powerbi.bootstrap(container, config);
    },
    Reset: function (container) {
        window.powerbi.reset(container);
    },
    Embed: function (dotNetObjectReference, container, type, accessToken, embedUri, embedId) {
        const models = powerBiClient.models;

        const config = {
            type: type,
            tokenType: models.TokenType.Embed,
            accessToken: accessToken,
            embedUrl: embedUri,
            id: embedId,
            permissions: models.Permissions.All,
            settings: {
                filterPaneEnabled: false,
                navContentPaneEnabled: false
            }
        };

        window.powerbi.embed(container, config);
    }
};