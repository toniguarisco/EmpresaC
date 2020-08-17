import React, { Component } from 'react';
import {Actions} from 'react-native-router-flux';
import LinearGradient from 'react-native-linear-gradient';
import RNPaypal from 'react-native-paypal-lib';
import { Table, Row, Rows } from 'react-native-table-component';

import {
  Platform,
  StyleSheet,
  Text,
  View,
  Button,
  TextInput,
  Image,
  ScrollView,
  TouchableOpacity,
  Alert,
  Modal,
  TouchableHighlight,
  Picker,
} from 'react-native';



type Props = {};
export default class Configuration extends Component<Props> {

  constructor(props){
    super(props);
    this.state = {
      correoDestino: "",
      monto: "",
      idioma: this.props.idioma,
      correo: this.props.correo,
      id: this.props.id,
      token: this.props.token,
      title:"",
      placeholder:"",
      placeholder2:"",
      button:"",
      error:"",
      errorTipo:"",
      modalVisible: false,
      modalTitle: "",
      message: "",
      descripcion: "",
      tableHead: "" ,
      tableData: [],
      tipo: "p",
      paydID: ""
    }
  }

  handleDestinyEmailChange= (Text) =>{
    this.setState({
      correoDestino: Text
    })
  }

  handleAmountChange= (Text) =>{
    this.setState({
      monto: Text
    })
  }

  handlePayIDChange= (Text) =>{
    this.setState({
      payID: Text
    })
  }

  handlePress = () =>{
  if ((this.state.correoDestino!="")&&(this.state.monto!="")){
   this.sendPayment();
  }else{
    this.setModalVisible(this.state.error, this.state.errorTipo);
  }
 }

 handlePress2 = () =>{
  if ((this.state.correoDestino!="")&&(this.state.monto!="")){
   let _Price = parseFloat(this.state.monto);
   RNPaypal.paymentRequest({
        clientId: 'AYjiaHGFtoRA_8ZlL_FvkhTq9TnETyyPVgFumd5NvHNp5rl5TbBppIXzdF2Y_FBTr14_8qkcbZiVP6vC',
        environment: RNPaypal.ENVIRONMENT.SANDBOX,
        intent: RNPaypal.INTENT.SALE,
        price: _Price,
        currency: 'USD',
        description: this.state.descripcion+this.state.correoDestino,
        acceptCreditCards: false
    }).then(response => {
        this.sendPaypalPayment();
    }).catch(err => {
        console.log(err.message)
    })

  }else{
    this.setModalVisible(this.state.error, this.state.errorTipo);
  }
 }

 handlePress3 = () =>{
  if ((this.state.correoDestino!="")&&(this.state.monto!="")&&(this.state.payID!="")){
   this.sendPaymentRequired();
  }else{
    this.setModalVisible(this.state.error, this.state.errorTipo);
  }
 }

 sendPayment = async() => {

 	let _Monto = parseFloat(this.state.monto);

  try {
    let response = await fetch(
      'http://ec2-18-234-178-93.compute-1.amazonaws.com/api/Monedero/Transferencia',{
       method: 'POST',
       headers: {
       Accept: 'application/json',
       'Content-Type': 'application/json',
       'Authorization': 'Bearer '+this.state.token
      },
      body: JSON.stringify({
      idUsuario: this.state.id,
      monto: _Monto,
      usuario: this.state.correoDestino,
      cuenta: " "
      })
     }
    );
    let responseJson = await response.json();
    if (responseJson == "transferencia exitosa"){
        Actions.pop();
    }else{
      this.setModalVisible("Error", this.state.errorTipo2);
    }
  } catch (error) {

   this.setModalVisible("Error", this.state.errorTipo3)
  }
}

sendPaypalPayment = async() => {

 	let _Monto = parseFloat(this.state.monto);

  try {
    let response = await fetch(
      'http://ec2-18-234-178-93.compute-1.amazonaws.com/api/Monedero/PagoPaypal',{
       method: 'POST',
       headers: {
       Accept: 'application/json',
       'Content-Type': 'application/json',
       'Authorization': 'Bearer '+this.state.token
      },
      body: JSON.stringify({
      idUsuario: this.state.id,
      monto: _Monto,
      usuario: this.state.correoDestino,
      cuenta: "Paypal"
      })
     }
    );
    let responseJson = await response.json();
    if (responseJson == "Pago Exitoso"){
        Actions.pop();
    }else{
      this.setModalVisible("Error", this.state.errorTipo2);
    }
  } catch (error) {

   this.setModalVisible("Error", this.state.errorTipo3)
  }
}

sendPaymentRequired = async() => {

  let _Monto = parseFloat(this.state.monto);
  let _ID = parseInt(this.state.payID);

  try {
    let response = await fetch(
      'http://ec2-18-234-178-93.compute-1.amazonaws.com/api/Monedero/PagoTienda',{
       method: 'POST',
       headers: {
       Accept: 'application/json',
       'Content-Type': 'application/json',
       'Authorization': 'Bearer '+this.state.token
      },
      body: JSON.stringify({
      idUsuario: this.state.id,
      monto: _Monto,
      usuario: this.state.correoDestino,
      idPago: _ID
      })
     }
    );
    let responseJson = await response.json();
    if (responseJson == "Pago Exitoso"){
        Actions.pop();
    }else{
      this.setModalVisible("Error", this.state.errorTipo2);
    }
  } catch (error) {

   this.setModalVisible("Error", this.state.errorTipo3)
  }
}

getPaymentData = async() => {
  try {
    let response = await fetch(
      'http://ec2-18-234-178-93.compute-1.amazonaws.com/api/Monedero/PagosPendientes?usuarioId='+this.state.id,{
       method: 'GET',
       headers: {
       Accept: 'application/json',
       'Content-Type': 'application/json',
       'Authorization': 'Bearer '+this.state.token
      }
     }
    ); 
    let responseJson = await response.json();
    let tempArray = [];

    responseJson.map((item)=>{
      let arrayObject = [ item.solicitante, item.monto, item.idPago ];
      tempArray.push(arrayObject);
    })

    this.setState({
      tableData: tempArray
    })
  }catch (error) {
   this.setModalVisible(this.state.error, this.state.errorTipo);
  }
}

 componentWillMount(){
  if(this.state.idioma=="es"){
    this.setState({
      title: "REALIZAR PAGO",
      placeholder: "Correo del usuario destino",
      placeholder2: "Monto",
      button: "ENVIAR",
      button2: "PAYPAL",
      error: "Error",
      errorTipo: "Algún campo está vacío.",
      errorTipo2: "Ha ocurrido un error",
      errorTipo3: "Verifique que esté conectado a una red WiFi o que tenga los datos móviles activado.",
      subtitle: "Por favor, ingrese los datos solicitados.",
      descripcion: "Usted enviará mediante Paypal dinero a: ",
      tableHead: ['Usuario','Monto', 'ID']
    })
  }else{
    this.setState({
      title: "MAKE PAYMENT",
      placeholder: "Destiny user's e-mail",
      placeholder2: "Amount",
      button: "SENDIT",
      button2: "PAYPAL",
      error: "Error",
      errorTipo: "Some field is empty.",
      errorTipo2: "An error has ocurred.",
      errorTipo3: "Check out you are connected to a WiFi network or that you have your mobile data activated.",
      subtitle: "Please, set the information required.",
      descripcion: "You will send money using Paypal to: ",
      tableHead: ['User','Amount', 'ID']
    })
  }
 }

 setModalVisible = (Text1, Text2) => {
    this.setState({
      modalVisible: !this.state.modalVisible,
      modalTitle: Text1,
      message: Text2
    });
  }

  render() {
   if (this.state.tipo == "p"){
    return (
     <View style={{flex: 1}}>
      <View style={styles.container}>
       <ScrollView contentContainerStyle={{flexGrow: 1, justifyContent: 'center'}}>
          <View style={styles.titles}>
           <View style={styles.title}>
            <LinearGradient style={{flex: 1, alignItems: "center", justifyContent: "center"}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FF9700', '#F8BD00', '#FFC900']}>
             <Text style={styles.text2}>
              {this.state.title}
             </Text>
            </LinearGradient>
           </View>
          </View>
          <View style={{flex: 1, flexDirection: "column", justifyContent: "center", alignItems: "center"}}>
           <Picker
              selectedValue={this.state.tipo}
              style={styles.picker2}
              onValueChange={(itemValue, itemIndex) => this.setState({tipo: itemValue})}>
              <Picker.Item label="Person" value="p" />
              <Picker.Item label="Bussiness" value="b" />
           </Picker>
           <Text style={styles.text3}>
            {this.state.subtitle}
           </Text>
           <View style={styles.inputContainer}>
            <TextInput
                style={styles.input}
                placeholder={this.state.placeholder}
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handleDestinyEmailChange}
                value={this.state.correoDestino} />
          </View>
          <View style={styles.inputContainer}>
            <TextInput
                style={styles.input}
                placeholder={this.state.placeholder2}
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handleAmountChange}
                value={this.state.monto} />
          </View>
          <TouchableOpacity onPress={this.handlePress}>
           <View style={styles.buttons}>
            <View style={styles.button}>
             <LinearGradient style={{paddingLeft: 80, paddingRight: 80}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FFCA12', '#C39515', '#D49C48']}>
                <Text style={styles.buttonText}>
                 {this.state.button}
                </Text>
              </LinearGradient>
            </View>
           </View>
          </TouchableOpacity>
          <TouchableOpacity onPress={this.handlePress2}>
           <View style={styles.buttons}>
            <View style={styles.button}>
             <LinearGradient style={{paddingLeft: 80, paddingRight: 80}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FFCA12', '#C39515', '#D49C48']}>
                <Text style={styles.buttonText}>
                 {this.state.button2}
                </Text>
              </LinearGradient>
            </View>
           </View>
          </TouchableOpacity>     
          <Modal
           animationType="slide"
           transparent={false}
           visible={this.state.modalVisible}
           >
           <View style={{flex:1, flexDirection: "column", justifyContent: "center", alignItems: "center", backgroundColor: "black"}}>
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
         </Modal>
        </View>
       </ScrollView>
      </View>
     </View>
    );
  }else{
    this.getPaymentData();
    return (
     <View style={{flex: 1}}>
      <View style={styles.container}>
       <ScrollView contentContainerStyle={{flexGrow: 1, justifyContent: 'center'}}>
          <View style={styles.titles}>
           <View style={styles.title}>
            <LinearGradient style={{flex: 1, alignItems: "center", justifyContent: "center"}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FF9700', '#F8BD00', '#FFC900']}>
             <Text style={styles.text2}>
              {this.state.title}
             </Text>
            </LinearGradient>
           </View>
          </View>
          <View style={{flex: 1, flexDirection: "column", justifyContent: "center", alignItems: "center"}}>
           <Picker
              selectedValue={this.state.tipo}
              style={styles.picker}
              onValueChange={(itemValue, itemIndex) => this.setState({tipo: itemValue})}>
              <Picker.Item label="Person" value="p" />
              <Picker.Item label="Bussiness" value="b" />
           </Picker>
           <Text style={styles.text3}>
            {this.state.subtitle}
           </Text>
           <View style={styles.inputContainer}>
            <TextInput
                style={styles.input}
                placeholder={this.state.placeholder}
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handleDestinyEmailChange}
                value={this.state.correoDestino} />
          </View>
          <View style={styles.inputContainer}>
            <TextInput
                style={styles.input}
                placeholder={this.state.placeholder2}
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handleAmountChange}
                value={this.state.monto} />
          </View>
          <View style={styles.inputContainer}>
            <TextInput
                style={styles.input}
                placeholder= "ID"
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handlePayIDChange}
                value={this.state.payID} />
          </View>
          <TouchableOpacity onPress={this.handlePress3}>
           <View style={styles.buttons}>
            <View style={styles.button}>
             <LinearGradient style={{paddingLeft: 80, paddingRight: 80}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FFCA12', '#C39515', '#D49C48']}>
                <Text style={styles.buttonText}>
                 {this.state.button}
                </Text>
              </LinearGradient>
            </View>
           </View>
          </TouchableOpacity>
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
         </Modal>
        </View>
       </ScrollView>
      </View>
     </View>
    );
  }
 }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    backgroundColor: "#111111",

 },
 welcome:{
  fontSize: 22,
  fontWeight: 'bold',
  marginBottom: 20,
  color: '#C39515',
  fontFamily: "Montserrat-SemiBold"
 },
 inputContainer: {
  backgroundColor: "white",
  flexDirection: 'row',
  alignItems: "center",
  justifyContent: "center",
  marginHorizontal: 10,
  marginBottom: 30,
  backgroundColor: 'rgba(0,0,0,0)',
  fontWeight: "bold"
 },
 input: {
  flex: 1,
  height: 40,
  color: "white"
 },
 buttons:{
  flexDirection: "row",
  marginTop: 10
 },
 button:{
  marginHorizontal: 10
 },
 buttonText: {
    fontSize: 14,
    fontWeight: "bold",
    textAlign: 'center',
    margin: 10,
    color: '#ffffff',
    backgroundColor: 'transparent'
   },
  text2: {
    fontSize: 14,
    fontWeight: "bold",
    textAlign: 'center',
    margin: 10,
    color: '#ffffff',
    backgroundColor: 'transparent',
    fontFamily: "Montserrat-Bold"
  },
  text3: {
    fontSize: 14,
    fontWeight: "bold",
    textAlign: 'center',
    marginBottom: 30,
    color: '#C39515',
    backgroundColor: 'transparent',
    fontFamily: "Montserrat-Bold"
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
 titles:{
  flexDirection: "row"
 },
 title:{
  flex: 1,
  height: 30
 },
 container2: { 
    flex: 1, 
    padding: 16, 
    paddingTop: 30, 
    backgroundColor: "#111111"
  },

  head: {  
    height: 40,  
    backgroundColor: "#FFC900"
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
  picker:{
   height: 35, 
   width: 200,
   backgroundColor: "rgba(195, 149, 21, 0.8)",
   marginBottom: 60,
   color: "white",
   marginTop: 75
  },
picker2:{
   height: 35, 
   width: 200,
   backgroundColor: "rgba(195, 149, 21, 0.8)",
   marginBottom: 60,
   color: "white",
  },
});