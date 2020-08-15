 import React, { Component } from 'react';
import {Actions} from 'react-native-router-flux';
import Header from "./Header/Header.js";
import SideMenu from "react-native-side-menu";
import Menu from "./Menu/Menu.js";
import { Table, Row, Rows } from 'react-native-table-component';
import LinearGradient from 'react-native-linear-gradient';

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
      id: this.props.id,
      correo: this.props.correo,
      contreseña: this.props.contraseña,
      isOpen: false,
      color: "",
      balanceGeneral: 0,
      idioma: this.props.idioma,
      title3:"",
      title4: "",
      error:"",
      errorTipo:"",
      modalVisible: false,
      modalTitle: "",
      message: "",
      tableHead: "" ,
      tableData: []
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
      'http://ec2-18-234-178-93.compute-1.amazonaws.com/api/Monedero/Balance?usuarioId='+this.state.id,{
       method: 'GET',
       headers: {
       Accept: 'application/json',
       'Content-Type': 'application/json',
      }
     }
    );
    let responseJson = await response.json();
    let tempArray = [];

    responseJson.readOperations.map((item)=>{
      let arrayObject = [ item.fecha, item.monto, item.operation, item.referencia ];
      tempArray.push(arrayObject);
    })

    this.setState({
      balanceGeneral: responseJson.monto,
      tableData: tempArray
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

 if (this.state.idioma=="es"){
  this.setState({
    title3: "BALANCE GENERAL (USD)",
    title4: "ULTIMOS MOVIMIENTOS",
    error: "Error de conexión",
    errorTipo: "Verifique que esté conectado a una red WiFi o que tenga los datos móviles activado.",
    tableHead: ['Fecha', 'Monto','Tipo', 'Referencia']

   })
  }else{
    this.setState({
    title3: "GENERAL BALANCE (USD)",
    title4: "LAST MOVEMENTS",
    error: "Network error",
    errorTipo: "Check out you are connected to a WiFi network or that you have your mobile data activated.",
    tableHead: ['Date', 'Amount','Type', 'Reference']
   })
  }
 }

componentDidMount() {
  this.interval = setInterval(() => {
    this.getUserData(this.state.correo);
  }, 1000);
}

componentWillUnmount() {
  clearInterval(this.interval);
}

  render() {

    return (
      <View style={styles.home}>
       <SideMenu menu={<Menu id={this.state.id} correo={this.state.correo} contraseña={this.state.contraseña} data={this.state.data} data2={this.state.data2} data3={this.state.data} onHandle={this.handleSideMenu} idiomaState={this.state.idioma}/>} isOpen={this.state.isOpen} onChange={(isOpen)=>this.updateMenu(isOpen)} >
        <View style={styles.header}>
          <Header onHandle={this.handleSideMenu}/>
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
                {this.state.balanceGeneral}
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
                <View style={{flex: 1, flexDirection:"column"}}>
                  <View style={styles.container2}>
                    <Table borderStyle={{borderWidth: 2, borderColor: "#C39515"}}>
                      <Row data={this.state.tableHead} style={styles.head} textStyle={styles.text}/>
                      <Rows data={this.state.tableData} style={{backgroundColor: "black"}} textStyle={styles.text}/>
                    </Table>
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
 box2:{
  flex: 1,
  flexDirection: "column",
  justifyContent: "center",
  alignItems: "center",
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

  container2: { 
    flex: 1, 
    padding: 16, 
    paddingTop: 30, 
    backgroundColor: "#1D1D1D"
  },

  head: {  
    height: 40,  
    backgroundColor: "#FFC900"
  },

  wrapper: { 
    flexDirection: 'row' 
  },

  title2: { 
    flex: 1, 
    backgroundColor: "#1D1D1D" 
  },

  row: {  
    height: 28  
  },

  text6: {
    fontSize: 10,
    fontWeight: "bold",
    textAlign: 'center',
    margin: 10,
    color: '#ffffff',
    backgroundColor: 'transparent',
    fontFamily: "Montserrat-Bold"
  },

});