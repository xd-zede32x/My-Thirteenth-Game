mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
    console.log("SKD Intialize");
  },

  PlayerInfoData: function () {
    myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
    myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));
  },

  RateGames: function () {
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

}); 