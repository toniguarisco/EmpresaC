import React, { Component } from 'react';
import Login from './src/Login/Login.js';
import Forgot from './src/Login/Forgot.js';
import Home from './src/Home/Home.js';
import Configuration from './src/Home/Menu/Configuration/Configuration.js';
import Payment from './src/Home/Menu/Payment/Payment.js';
import Request from './src/Home/Menu/Request/Request.js';
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
        <Scene key="forgot" component={Forgot} title="Reestablacer contraseña" hideNavBar={false}/>
        <Scene key="home" component={Home} title="Home" type="reset" hideNavBar/>
        <Scene key="configuration" component={Configuration} title="Configuración" hideNavBar={false}/>
        <Scene key="payment" component={Payment} title="Realizar pago" hideNavBar={false}/>
        <Scene key="request" component={Request} title="Solicitar dinero" hideNavBar={false}/>
       </Stack>
      </Router>
    );
  }
}
