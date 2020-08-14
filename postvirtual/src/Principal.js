import React, { Component } from 'react';
import {Actions} from 'react-native-router-flux';
import SideMenu from "react-native-side-menu";
import LinearGradient from 'react-native-linear-gradient';
import { AreaChart, Path, YAxis} from 'react-native-svg-charts';
import * as shape from 'd3-shape'
import Barra from "./Barra.js";
import Menu from "./Menu.js";

import {
  FlatList,
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
import { TouchableOpacity } from 'react-native-gesture-handler';



type Props = {};
export default class Home extends Component<Props> {

  constructor(props){
    super(props);
    this.state = {
      id: this.props.id,
      correo: this.props.correo,
      contraseña: this.props.contraseña,
      isOpen: false,
      color: "",
      balance: 0,
      title1:"",
      title2: "",
      error:"",
      errorTipo:"",
      modalVisible: false,
      modalTitle: "",
      message: "",
      lista: [
        {usuario: "",
        monto: "",
        fecha: "",
        referencia: ""}
      ]
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


 getUserData = async(correo) => {
  try {
    let response = await fetch(
      'API',{
       method: 'GET',
       headers: {
       Accept: 'application/json',
       'Content-Type': 'application/json',
      },
      /* body: JSON.stringify({
      usuario: this.state.usuario,
      fecha: this.state.fecha
      }) */
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

renderItem = ({item}) => (
  <TouchableOpacity>
    <View style={styles.item}>
      <View></View>
      <Text># {item.referencia} | {item.fecha} | {item.usuario}  |  $ {item.monto}</Text>
    </View>
  </TouchableOpacity>
)

FlatListseparador = () => { 
  return(
    <View
    style={{height:1, width: '100%', backgroundColor:'#f5C39515'}}
  />
  )
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
    return (
      <View style={styles.home}>
       <SideMenu menu={<Menu id={this.state.id} correo={this.state.correo} contraseña={this.state.contraseña} data={this.state.data} data2={this.state.data2} data3={this.state.data} onHandle={this.handleSideMenu} chartState={this.state.charts} idiomaState={this.state.idioma}/>} isOpen={this.state.isOpen} onChange={(isOpen)=>this.updateMenu(isOpen)} >
        <View style={styles.header}>
          <Barra onHandle={this.handleSideMenu} onSwitch={this.switchCharts}/>
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
            <View style={{ flex: 1, paddingTop: 5, flexDirection: 'row'}}>
              <FlatList
                data={this.state.lista}
                keyExtractor={({ id }, index) => id}
                renderItem={this.renderItem}
                ItemSeparatorComponent = {this.FlatListseparador}
              />
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
  },

  item: {
    padding: 10,
    fontSize: 10,
    height: 44,
}
});