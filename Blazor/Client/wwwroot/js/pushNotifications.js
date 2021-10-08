////{
////    "subject": "mailto: <pampana.alessio@gmail.com>",
////        "publicKey": "BEG6WfJCPjabW8Tl2DdqSfsGtk2PX1EAR57vOvsht45gQPLJ9MrRuIKQ7eNmi6Y5_t618tLP1hcAUITt8W2DbRI",
////            "privateKey": "NMZjf1KUs-rO2rGEBquOHCEulKVJj4gPgO_jtcGP7ts"
////}
(function () {
    const applicationServerPublicKey = 'BEG6WfJCPjabW8Tl2DdqSfsGtk2PX1EAR57vOvsht45gQPLJ9MrRuIKQ7eNmi6Y5_t618tLP1hcAUITt8W2DbRI';
    window.blazorPushNotifications = {
        requestSubscription: async () => {
            const worker = await navigator.serviceWorker.getRegistration();
            const existingSubscription = await worker.pushManager.getSubscription();
            if (!existingSubscription) {
                const newSubscription = await subscribe(worker);
                if (newSubscription) {
                    return {
                        url: newSubscription.endpoint,
                        p256dh: arrayBufferToBase64(newSubscription.getKey('p256dh')),
                        auth: arrayBufferToBase64(newSubscription.getKey('auth'))
                    };
                }
            }
        }
    };

    async function subscribe(worker) {
        try {
            return await worker.pushManager.subscribe({
                userVisibleOnly: true,
                applicationServerKey: applicationServerPublicKey
            });
        } catch (error) {
            if (error.name === 'NotAllowedError') {
                return null;
            }
            throw error;
        }
    }

    function arrayBufferToBase64(buffer) {
        var binary = '';
        var bytes = new Uint8Array(buffer);
        var len = bytes.byteLength;
        for (var i = 0; i < len; i++) {
            binary += String.fromCharCode(bytes[i]);
        }
        return window.btoa(binary);
    }
})();