import * as firebase from 'firebase';

const config  = {
    apiKey: "AIzaSyDx_pc_e8vykSB1UqW1ake8jaWIv7Mc-LI",
    authDomain: "finalproject-30d08.firebaseapp.com",
    databaseURL: "https://finalproject-30d08.firebaseio.com",
    projectId: "finalproject-30d08",
    storageBucket: "finalproject-30d08.appspot.com",
    messagingSenderId: "825060631647"
  };

  export const firebaseApp = firebase.initializeApp(config);