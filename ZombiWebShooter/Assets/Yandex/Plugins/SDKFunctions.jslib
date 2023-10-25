mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
    },


  GetPlayerData: function () {
      console.log(player.getName());
      myGameInstance.SendMessage('Yandex', 'SetNamePlayer', player.getName() );
    },

  GetAuthStatus: function () {
       
        myGameInstance.SendMessage('Yandex', 'SetStatusAuth', player.getMode());
  },
    
 RateGame: function () {
     ysdk.feedback.canReview()
         .then(({ value, reason }) => {
             if (value) {
                 ysdk.feedback.requestReview()
                     .then(({ feedbackSent }) => {
                         console.log(feedbackSent);
                     })
             } else {
                 console.log(reason)
             }
         })



    },

    SaveCoins: function (_coins) {
        var dateString = UTF8ToString(_coins);
        var myobj = JSON.parse(dateString);
        player.setData(myobj);
    },
    LoadCoins: function () {
        player.getData().then(_date => {
            const myJSON = JSON.stringify('Yandex', 'Load', myJSON)
        });

    },


    AddCoinsExtern: function (value) {
        ysdk.adv.showRewardedVideo({
            callbacks: {
                onOpen: () => {
                    console.log('Video ad open.');
                },
                onRewarded: () => {
                    console.log('Rewarded!');
                    myGameInstance.SendMessage('Yandex', 'AddMoneyForAdd', value)
                },
                onClose: () => {
                    console.log('Video ad closed.');
                },
                onError: (e) => {
                    console.log('Error while open video ad:', e);
                }
            }
        
        });
    },


    ShowADSInGame: function () {

        ysdk.adv.showRewardedVideo({
            callbacks: {
                onOpen: () => {
                    console.log('Video ad open.');
                },
                onRewarded: () => {
                    console.log('Rewarded!');
                    myGameInstance.SendMessage('Yandex', 'RespawnByADS')
                },
                onClose: () => {
                    console.log('Video ad closed.');
                },
                onError: (e) => {
                    console.log('Error while open video ad:', e);
                }
            }


        });

    },

    ShowADSExternal: function () {

        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function (wasShown) {
                    // some action after close
                },
                onError: function (error) {
                    // some action on error
                }
            }
        });


    },

});