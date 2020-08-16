import React, { Component } from 'react';
import {Actions} from 'react-native-router-flux';
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
  TouchableOpacity,
  ImageBackground,
  Alert,
  ActivityIndicator,
  Modal,
  TouchableHighlight
} from 'react-native';



type Props = {};
export default class Login extends Component<Props> {

  constructor(props){
    super(props);
    this.state = {
      correo: "",
      contraseña: "",
      data: null,
      modalVisible: false,
      modalTitle: "",
      message: ""
    }
  }

  handleCorreoChange = (Text) =>{
    this.setState({
      correo: Text
    })
  }

  handlePasswordChange= (Text) =>{
    this.setState({
      contraseña: Text
    })
  }
  
  loginApp = async() => {

  this.setState({
  	data: 1
  })
  try {
    let response = await fetch(
      'http://ec2-18-234-178-93.compute-1.amazonaws.com/api/App/login',{
       method: 'POST',
       headers: {
       Accept: 'application/json',
       'Content-Type': 'application/json',
      },
      body: JSON.stringify({
      usuario: this.state.correo,
      clave: this.state.contraseña
      })
     }
    );
    let responseJson = await response.json();
    if (responseJson.statusCode==200){
    	this.setState({
  	     data: null
        })
        Actions.pop();
        Actions.home({token: responseJson.value.token, id: responseJson.value.id, correo: this.state.correo, contraseña: this.state.contraseña, idioma: "es"});
    }else{
      this.setState({
  	   data: null
      })
      this.setModalVisible("Error", "Usuario y/o contraseña incorrecta");
    }
  } catch (error) {
   this.setState({
  	data: null
   });
   this.setModalVisible("Error de conexión", "Verifique que esté conectado a una red WiFi o que tenga los datos móviles activado.")
  }
}


 handleLoginPress = () =>{
  if ((this.state.correo!="") && (this.state.contraseña!="")){
   this.loginApp();
  }else{
    this.setModalVisible("Error","Algún campo se encuentra vacío.");
  }
 }

 handleForgot = () =>{
   Actions.forgot();
 }

 setModalVisible = (Text1, Text2) => {
    this.setState({
      modalVisible: !this.state.modalVisible,
      modalTitle: Text1,
      message: Text2
    });
  }

  render() {
    const background = "../Images/ImageBackground.jpg";
    if (!this.state.data){
    return (
      <View style={{flex: 1}}>
        <ImageBackground resizeMode={'stretch'} style={{flex: 1}} source={require(background)}>
           <View style={{flex: 1, marginBottom: 15, marginTop: 100}}>
            <ScrollView contentContainerStyle={{flexGrow: 1, justifyContent: 'center', alignItems: "center"}}>
              <View style={styles.inputContainer}>
              <TextInput style={styles.input}
                  placeholder="Usuario"
                  inlineImageLeft='user'
                  inlineImagePadding={10}
                  placeholderTextColor="#A1A1A1"
                  underlineColorAndroid="#C39515"
                  selectionColor="#C39515"
                  onChangeText={this.handleCorreoChange}
                  value={this.state.correo} />
              </View>
             <View style={styles.inputContainer}>
              <TextInput
                  style={styles.input}
                  placeholder="Contraseña"
                  inlineImageLeft='key'
                  inlineImagePadding={10}
                  placeholderTextColor="#A1A1A1"
                  underlineColorAndroid="#C39515"
                  selectionColor="#C39515"
                  secureTextEntry={true}
                  onChangeText={this.handlePasswordChange}
                  value={this.state.contraseña}/>
            </View>
            <TouchableOpacity onPress={this.handleLoginPress}>
             <View style={styles.buttons}>
              <View style={styles.button}>
               <LinearGradient style={{paddingLeft: 80, paddingRight: 80}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FFCA12', '#C39515', '#D49C48']}>
                <Text style={styles.buttonText}>
                 ENTRA AQUÍ
                </Text>
               </LinearGradient>
              </View>
             </View>
            </TouchableOpacity>
            <View style={styles.forgotContainer}>
              <TouchableOpacity onPress={this.handleForgot}>
               <Text style={styles.forgot}>
                ¿Olvidaste tu contraseña?
               </Text>
              </TouchableOpacity>
             </View>
             <View style={styles.developer}>
                <Text style={styles.text3}>
                   Desarrollado por Empresa C
                </Text>
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
          </ScrollView>
         </View>
        </ImageBackground>
      </View>
    )
   }else{
   	return(
   	   <View style={{flex: 1}}>
        <ImageBackground resizeMode={'stretch'} style={{flex: 1}} source={require(background)}>
	   	 <View style={styles.Spinner}>
	       <ActivityIndicator size="large" color="#C39515"/>
	         <Text style={styles.text2}>
	           Cargando...
	         </Text>
	     </View>
	    </ImageBackground>
      </View>
     )
   }
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center"
 },
 welcome:{
  flexDirection: "column",
  justifyContent: "center",
  alignItems: "center",
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
  marginBottom: 10,
  backgroundColor: 'rgba(0,0,0,0)',
  fontWeight: "bold"

 },
 input: {
  flex: 1,
  height: 40,
  color: "white"
 },
 image:{
  width: 200,
  height: 217,
  marginTop: -5,
  marginBottom: -5
 },
 buttons:{
  flexDirection: "row",
  marginTop: 10,
  paddingLeft: 15,
  paddingRight: 15,
 },
 button:{
  marginHorizontal: 10,
 },
 forgotContainer:{
  justifyContent: "center",
  alignItems: "center",
  backgroundColor: 'rgba(0,0,0,0)',
  marginTop: 20
 },
 forgot:{
  flexDirection: "column",
  justifyContent: "center",
  alignItems: "center",
  fontSize: 15,
  fontWeight: 'bold',
  color: '#C39515',
  fontFamily: "Montserrat-SemiBold"
 },
 background: {
  flex: 1,
  width: '100%',
  height: '100%',
  resizeMode: 'stretch',
  position: 'absolute'
 },
  buttonText: {
    fontSize: 14,
    fontWeight: "bold",
    textAlign: 'center',
    margin: 10,
    color: '#ffffff',
    backgroundColor: 'transparent',
  },
  text: {
    fontSize: 10,
    textAlign: 'center',
    color: '#C39515',
    backgroundColor: 'transparent',
    fontFamily: "Montserrat-SemiBold"
  },
  text2: {
    fontSize: 10,
    fontWeight: "bold",
    textAlign: 'center',
    color: '#C39515',
    backgroundColor: 'transparent',
    fontFamily: "Montserrat-SemiBold"
  },
  text3: {
    fontSize: 8,
    textAlign: 'center',
    color: '#C39515',
    backgroundColor: 'transparent',
    fontFamily: "Montserrat-SemiBold"
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
  texts:{
    flexDirection: "row",
  	marginTop: 20
  },
  developer:{
    flexDirection: "row",
    marginTop: 20
  },
  Spinner: {
  flex: 1,
  justifyContent: 'center',
  alignItems: 'center',
 }
});
