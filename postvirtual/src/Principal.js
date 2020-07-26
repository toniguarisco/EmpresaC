import React, { Component } from 'react';
import {Actions} from 'react-native-router-flux';
import SideMenu from "react-native-side-menu";
import LinearGradient from 'react-native-linear-gradient';
import { AreaChart, Path, YAxis} from 'react-native-svg-charts';
import * as shape from 'd3-shape'
import Barra from "./Barra.js";
import Menu from "./Menu.js";

import {
  Platform,
  StyleSheet,
  Text,
  View,
  Button,
  TextInput,
  Image,
  ScrollView,
  Modal,
  TouchableHighlight
} from 'react-native';



type Props = {};
export default class Home extends Component<Props> {

  constructor(props){
    super(props);
    this.state = {
      token: this.props.token,
      correo: this.props.correo,
      contreseña: this.props.contraseña,
      isOpen: false,
      charts: this.props.charts,
      color: "",
      data: [],
      balance: 0,
      title3:"",
      title4: "",
      error:"",
      errorTipo:"",
      modalVisible: false,
      modalTitle: "",
      message: ""
    }
  }

 handleSideMenu = () =>{
  this.setState({
    isOpen: !this.state.isOpen
  });
 }

 updateMenu = (isopen) =>{
  this.setState({
    isOpen: isopen
  })
 }
 switchCharts = () =>{
   if (!this.state.charts){
      Actions.home({token: this.state.token, correo: this.state.correo, contraseña: this.state.contraseña, charts: !this.state.charts, data: this.state.data, data2: this.state.data2, data3: this.state.data});
   }else{
      Actions.home({token: this.state.token, correo: this.state.correo, contraseña: this.state.contraseña, charts: !this.state.charts, data: this.state.data, data2: this.state.data2, data3: this.state.data});
   }
 }

 getUserData = async(correo) => {
  try {
    let response = await fetch(
      'API',{
       method: 'GET',
       headers: {
       Accept: 'application/json',
       'Content-Type': 'application/json',
      }
     }
    );
    let responseJson = await response.json();
    this.setState({
      //
    })
  }catch (error) {
   this.setModalVisible(this.state.error, this.state.errorTipo);
  }
}

setModalVisible = (Text1, Text2) => {
    this.setState({
      modalVisible: !this.state.modalVisible,
      modalTitle: Text1,
      message: Text2
    });
  }
 

componentWillMount(){

 this.getUserData(this.state.correo);

 if(this.state.charts==false){
  this.setState({
    data: [ 1300, 1200, 1400, 1500 ],
    color: "rgba(195, 149, 21, 0.2)"
  })
 }else{
  this.setState({
    data: [ 700, 950, 800, 1000 ],
    color: "rgba(169, 169, 169, 0.2)"
  })
 }

  if(this.state.charts==false){
  this.setState({
    title3: "BALANCE GENERAL ($)",
    title4: "ULTIMOS MOVIMIENTOS",
    error: "Error de conexión",
    errorTipo: "Verifique que esté conectado a la red."
   })
  }else{
    this.setState({
    title3: "BALANCE GENERAL ($)",
    title4: "ULTIMOS MOVIMIENTOS",
    error: "Error de conexión",
    errorTipo: "Verifique que esté conectado a la red."
   })
  }
}

componentDidMount() {
  this.interval = setInterval(() => {
    this.getUserData(this.state.correo);
  }, 10000);
}

componentWillUnmount() {
  clearInterval(this.interval);
}

  render() {

    const dias = ["14/07/2018","15/07/2018","16/07/2018","17/07/2018"]
    const axesSvg = { fontSize: 10, fill: 'white' };
    const verticalContentInset = { top: 9, bottom: 9 }
    const xAxisHeight = 45;
    const Line = ({ line }) =>{
     if(this.state.charts==false){
     	return(
       <Path key={ 'line ' } d={ line } stroke={ "#C39515" } fill={ 'none' }/>
      )
     }else{
     	return(
     	 <Path key={ 'line ' } d={ line } stroke={ "#A9A9A9" } fill={ 'none' }/>
       )
      }
    }

    return (
      <View style={styles.home}>
       <SideMenu menu={<Menu token={this.state.token} correo={this.state.correo} contraseña={this.state.contraseña} data={this.state.data} data2={this.state.data2} data3={this.state.data} onHandle={this.handleSideMenu} chartState={this.state.charts} idiomaState={this.state.idioma}/>} isOpen={this.state.isOpen} onChange={(isOpen)=>this.updateMenu(isOpen)} >
        <View style={styles.header}>
          <Header onHandle={this.handleSideMenu} onSwitch={this.switchCharts}/>
        </View> 
        <View style={{flex: 1}}>
         <View style={styles.container}>
          <ScrollView contentContainerStyle={{flexGrow: 1, flexDirection: "column", alignItems: "center"}}>
           <View style={styles.titles}>
              <View style={styles.title}>
               <LinearGradient style={{flex: 1, alignItems: "center", justifyContent: "center"}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FF9700', '#F8BD00', '#FFC900']}>
                <Text style={styles.text}>
                 {this.state.title3}
                </Text>
               </LinearGradient>
              </View>
             </View>
             <View style={styles.infoBox}>
              <View style={styles.box}>
               <Text style={styles.text2}>
                {this.state.balance}
               </Text>
              </View>
            </View>
            <View style={styles.titles}>
              <View style={styles.title}>
               <LinearGradient style={{flex: 1, alignItems: "center", justifyContent: "center"}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FF9700', '#F8BD00', '#FFC900']}>
                <Text style={styles.text}>
                 {this.state.title4}
                </Text>
               </LinearGradient>
              </View>
            </View>
            <View style={{ flex: 1, flexDirection: 'row'}}>
              <YAxis data={this.state.data} numberOfTicks={5} style={{ marginBottom: xAxisHeight}} contentInset={verticalContentInset} svg={axesSvg}/>
                <View style={{flex: 1, flexDirection:"column"}}>
                  <AreaChart style={{ flex: 1}} data={ this.state.data } svg={{ fill: this.state.color }} contentInset={{ top: 15, bottom: 15 }} curve={ shape.curveNatural }>
                   <Line/>
                  </AreaChart>
                <View style={{ flex: 1, height: 20, flexDirection:"row", alignItems:"center", justifyContent:"space-between"}}>
                  {dias.map((item) => <Text style={{color: "white", fontSize: 10}}>{item}</Text>)}
                </View>
              </View>
            </View>
            <Modal
              animationType="slide"
              transparent={false}
              visible={this.state.modalVisible}
              >
             <View style={{flex:1, flexDirection: "column", justifyContent: "center", alignItems: "center", backgroundColor: "black"}}>
              <View>
               <Text style={styles.text4}>
                {this.state.modalTitle}
               </Text>
               <Text style={styles.text5}>
                {this.state.message}
               </Text>
               <TouchableHighlight
                onPress={() => {
                  this.setState({modalVisible: !this.state.modalVisible})
                }}
                style={{flexDirection: "column", justifyContent: "center", alignItems: "center"}}>
                <View style={styles.buttons}>
                 <View style={styles.button}>
                  <LinearGradient style={{paddingLeft: 40, paddingRight: 40}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FFCA12', '#C39515', '#D49C48']}>
                   <Text style={styles.buttonText}>
                    OK
                   </Text>
                  </LinearGradient>
                 </View>
                </View>
               </TouchableHighlight>
              </View>
             </View>
           </Modal>
          </ScrollView>
         </View>
        </View>
       </SideMenu>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: "column",
    justifyContent: "center",
    backgroundColor: "#111111",

 },
 welcome:{
  flexDirection: "column",
  justifyContent: "center",
  alignItems: "center",
  fontSize: 22,
  fontWeight: 'bold',
  marginBottom: 20,
  color: '#C39515'
 },
 home:{
  flex: 1,
  flexDirection: "column",
  backgroundColor: "#111111"
 },
 header:{
  backgroundColor: "black"
 },
 titles:{
  flexDirection: "row"
 },
 title:{
  flex: 1,
  height: 30
 },
 text: {
    fontSize: 14,
    fontWeight: "bold",
    textAlign: 'center',
    margin: 10,
    color: '#ffffff',
    backgroundColor: 'transparent',
    fontFamily: "Montserrat-Bold"
  },
  text2: {
    fontSize: 30,
    fontWeight: "bold",
    textAlign: 'center',
    color: '#ffffff',
    backgroundColor: 'transparent',
    fontFamily: "Montserrat-Bold"
  },
 infoBox:{
 	flexDirection: "row",
 	alignItems: "center",
 	backgroundColor: "#1D1D1D"
 },
 box:{
 	flex: 1,
 	flexDirection: "column",
 	justifyContent: "center",
 	alignItems: "center",
 	height: 50,
 	backgroundColor: "#1D1D1D",
 	paddingVertical: 30
 },
 oro:{
    fontSize: 12,
    textAlign: 'center',
    color: '#C39515',
    backgroundColor: 'transparent',
    fontFamily: "Montserrat-Bold"
  },
  plata:{
    fontSize: 12,
    textAlign: 'center',
    color: '#A9A9A9',
    backgroundColor: 'transparent',
    fontFamily: "Montserrat-Bold"
  },
  buttonText: {
    fontSize: 14,
    fontWeight: "bold",
    textAlign: 'center',
    margin: 10,
    color: '#ffffff',
    backgroundColor: 'transparent',
  },
  text4: {
    fontSize: 20,
    fontWeight: "bold",
    textAlign: 'center',
    color: '#C39515',
    backgroundColor: 'transparent',
    fontFamily: "Montserrat-SemiBold",
    marginBottom: 5
  },
  text5: {
    fontSize: 15,
    fontWeight: "bold",
    textAlign: 'center',
    color: '#C39515',
    backgroundColor: 'transparent',
    fontFamily: "Montserrat-SemiBold",
    marginBottom: 10
  }
});