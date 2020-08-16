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
export default class Forgot extends Component<Props> {

  constructor(props){
    super(props);
    this.state = {
      correo: "",
      data: null,
      modalVisible: false,
      modalTitle: "",
      message: "",
      flag: false
    }
  }

  setModalVisible = (Text1, Text2, Flag) => {
  if (Flag==false){
    this.setState({
      modalVisible: !this.state.modalVisible,
      modalTitle: Text1,
      message: Text2,
      flag: false
    });
   }else{
    this.setState({
      modalVisible: !this.state.modalVisible,
      modalTitle: Text1,
      message: Text2,
      flag: true
    });
   }
  }

  handleCorreoChange= (Text) =>{
    this.setState({
      correo: Text
    })
  }
 
 forgotPassword = async() => {
  this.setState({
    data: 1
  })
  try {
    let response = await fetch(
      'http://ec2-18-234-178-93.compute-1.amazonaws.com/api/App/recuperarContaseña',{
       method: 'POST',
       headers: {
       Accept: 'application/json',
       'Content-Type': 'application/json',
      },
      body: JSON.stringify({
      email: this.state.correo,
      })
     }
    );
    let responseJson = await response.json();
    if (responseJson == "Se envio un correo a "+this.state.correo+" con su nueva clave"){
        this.setState({
         data: null
        })
      this.setModalVisible("Se envio un correo a "+this.state.correo+" con su nueva clave",responseJson.message, true);
    }else{
     this.setState({
      data: null
     })
     this.setModalVisible("Error","Algo fallo al recuperar contraseña", false);
    }
  } catch (error) {
    this.setState({
    data: null
  });
    this.setModalVisible("Error de conexión","Verifique que esté conectado a una red WiFi o que tenga los datos móviles activado.", false);
  }
}

  handlePress = () =>{
  if (this.state.correo!=""){
   this.forgotPassword();
  }else{
    this.setModalVisible("Error","Debe ingresar un correo electrónico.", false);
  }
 }

  render() {
    const background = "./resources/ImageBackground.jpg";
    if (!this.state.data){
    return (
      <View style={{flex: 1}}>
        <ImageBackground resizeMode={'stretch'} style={{flex: 1}} source={require(background)}>
         <View style={{flex: 1, marginBottom: 15}}>
          <ScrollView contentContainerStyle={{flexGrow: 1, justifyContent: 'center', alignItems: "center"}}>
             <Text style={styles.welcome}>
                Escribe tu correo electrónico
             </Text>
             <View style={styles.inputContainer}>
              <TextInput
                style={styles.input}
                placeholder="Correo"
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handleCorreoChange}
                value={this.state.correo} />
             </View>
             <TouchableOpacity onPress={this.handlePress}>
              <View style={styles.buttons}>
               <View style={styles.button}>
                <LinearGradient style={{paddingLeft: 80, paddingRight: 80}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FFCA12', '#C39515', '#D49C48']}>
                    <Text style={styles.buttonText}>
                      ACEPTAR
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
                  if (this.state.flag==false){
	               this.setState({modalVisible: !this.state.modalVisible});
	              }else{
	              	Actions.login();
	              }
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
    )}
    else{
      return(
       <View style={{flex: 1}}>
        <ImageBackground resizeMode={'stretch'} style={{flex: 1}} source={require(background)}>
         <View style={styles.Spinner}>
          <ActivityIndicator size="large" color="#C39515"/>
           <Text style={styles.text}>
             Por favor espere...
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
 buttons:{
  flexDirection: "row",
  marginTop: 10
 },
 button:{
  marginHorizontal: 10
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
  Spinner: {
  flex: 1,
  justifyContent: 'center',
  alignItems: 'center',
 },
 text: {
    fontSize: 10,
    fontWeight: "bold",
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
  }
});
