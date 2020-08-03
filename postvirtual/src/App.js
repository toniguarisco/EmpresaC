import 'react-native-gesture-handler';
import * as React from 'react';
import { Component } from 'react';
import { NavigationContainer } from '@react-navigation/native';
import {Scene, Router, Stack} from 'react-native-router-flux';
import Login from './Login.js';
import Olvido from './Olvido.js';
import Principal from './Principal.js';
import Opciones from './Opciones.js';
import Pago from './Pago.js';

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
        <Scene key="olvido" component={Olvido} title="Reestablacer contraseña" hideNavBar={false}/>
        <Scene key="principal" component={Principal} title="Inicio" type="reset" hideNavBar/>
        <Scene key="opciones" component={Opciones} title="Opciones" hideNavBar={false}/>
        <Scene key="pago" component={Pago} title="Pagos" hideNavBar={false}/>
       </Stack>
      </Router>
    );
  }
}