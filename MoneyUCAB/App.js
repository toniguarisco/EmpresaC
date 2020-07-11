import React, { Component } from 'react';
import Login from './src/Login/Login.js';
import {Scene, Router, Stack} from 'react-native-router-flux';
import {
  Platform,
  StyleSheet,
  Text,
  View
} from 'react-native';

type Props = {};
export default class App extends Component<Props> {
 
  render() {
    return (
      <Router navigationBarStyle={{backgroundColor: "black"}} titleStyle={{color: "#C39515"}} tintColor="#C39515">
       <Stack key="root">
        <Scene key="login" component={Login} title="Login" type="reset" hideNavBar/>
       </Stack>
      </Router>
    );
  }
}
