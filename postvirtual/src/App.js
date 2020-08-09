import 'react-native-gesture-handler';
import * as React from 'react';
import { Component } from 'react';
import { NavigationContainer } from '@react-navigation/native';
import {Scene, Router, Stack} from 'react-native-router-flux';
import { MenuProvider } from 'react-native-popup-menu';
import Login from './Login.js';
import Olvido from './Olvido.js';
import Principal from './Principal.js';
import Opciones from './Opciones.js';
import Pago from './Pago.js';
import Operaciones from './Operaciones.js';
import Reintegro from './Reintegro.js';
import CambioClave from './CambioClave.js';

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
      <MenuProvider>
      <Router navigationBarStyle={{backgroundColor: "black"}} titleStyle={{color: "#C39515"}} tintColor="#C39515">
       <Stack key="root">
        <Scene key="login" component={Login} title="Login" type="reset" hideNavBar/>
        <Scene key="olvido" component={Olvido} title="Reestablacer contraseña" hideNavBar={false}/>
        <Scene key="principal" component={Principal} title="Inicio" type="reset" hideNavBar/>
        <Scene key="cambioclave" component={CambioClave} title="Cambiar contraseña" hideNavBar={false}/>
        <Scene key="pago" component={Pago} title="Solicitar pago" hideNavBar={false}/>
        <Scene key="operaciones" component={Operaciones} title="Operaciones" hideNavBar={false}/>
        <Scene key="reintegro" component={Reintegro} title="Reintegros" hideNavBar={false}/>
        <Scene key="opciones" component={Opciones} title="Perfil" hideNavBar={false}/>
       </Stack>
      </Router>
      </MenuProvider>
    );
  }
}