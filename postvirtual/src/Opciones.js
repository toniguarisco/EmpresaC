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
  Alert,
  Modal,
  TouchableHighlight
} from 'react-native';



type Props = {};
export default class Configuration extends Component<Props> {

  constructor(props){
    super(props);
    this.state = {
      usuario: "",
      numidentificacion: "",
      telefono: "",
      direccion: "",
      nombrerep: "",
      apellidorep: "",
      correo: this.props.correo,
      id: this.this.props.id,
      title:"",
      button:"",
      error:"",
      errorTipo:"",
      modalVisible: false,
      modalTitle: "",
      message: ""
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

  handleReferenceChange= (Text) =>{
    this.setState({
      referencia: Text
    })
  }

  handlePress = () =>{
  if ((this.state.correoDestino!="")&&(this.state.monto!="")&&(this.state.referencia!="")){
   Actions.pop();
  }else{
    this.setModalVisible(this.state.error, this.state.errorTipo);
  }
 }

 handleCambio = () =>{
  Actions.cambioclave({title:"Cambiar Contraseña", correo: this.state.correo});
  }

 requestMoney = async(correo) => {
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
      //Asignacion de valores 
    })
  }catch (error) {
   this.setModalVisible(this.state.error, this.state.errorTipo);
  }
}
 
componentWillMount(){
  this.setState({
    title: "OPCIONES DE PERFIL",
    error: "Error",
    errorTipo: "Algún campo está vacío.",
  })
}

 setModalVisible = (Text1, Text2) => {
    this.setState({
      modalVisible: !this.state.modalVisible,
      modalTitle: Text1,
      message: Text2
    });
  }

  render() {
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
           <View style={styles.inputContainer}>
            <TextInput
                style={styles.input}
                placeholder={this.state.usuario}
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handleDestinyEmailChange}
                value={this.state.correoDestino} />
          </View>
          <View style={styles.inputContainer}>
            <TextInput editable={false} selectTextOnFocus={false}
                style={styles.input}
                placeholder={this.state.numidentificacion}
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handleReferenceChange}
                value={this.state.referencia} />
          </View>
          <View style={styles.inputContainer}>
            <TextInput
                style={styles.input}
                placeholder={this.state.correo}
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handleAmountChange}
                value={this.state.monto} />
          </View>
          <View style={styles.inputContainer}>
            <TextInput
                style={styles.input}
                placeholder={this.state.telefono}
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handleAmountChange}
                value={this.state.monto} />
          </View>
          <View style={styles.inputContainer}>
            <TextInput
                style={styles.input}
                placeholder={this.state.direccion}
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handleAmountChange}
                value={this.state.monto} />
          </View>
          <View style={styles.inputContainer}>
            <TextInput
                style={styles.input}
                placeholder={this.state.nombrerep}
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handleAmountChange}
                value={this.state.monto} />
          </View>
          <View style={styles.inputContainer}>
            <TextInput
                style={styles.input}
                placeholder={this.state.apellidorep}
                placeholderTextColor="#A1A1A1"
                underlineColorAndroid="#C39515"
                selectionColor="#C39515"
                onChangeText={this.handleAmountChange}
                value={this.state.monto} />
          </View>       
          <TouchableOpacity onPress={this.handleCambio}>
           <View style={styles.buttons}>
            <View style={styles.button}>
             <LinearGradient style={{paddingLeft: 80, paddingRight: 80}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FFCA12', '#C39515', '#D49C48']}>
                <Text style={styles.buttonText}>
                 CAMBIAR CONTRASEÑA
                </Text>
              </LinearGradient>
            </View>
           </View>
          </TouchableOpacity>
          <TouchableOpacity onPress={this.handlePress}>
           <View style={styles.buttons}>
            <View style={styles.button}>
             <LinearGradient style={{paddingLeft: 80, paddingRight: 80}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FFCA12', '#C39515', '#D49C48']}>
                <Text style={styles.buttonText}>
                 GUARDAR
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
            <TouchableOpacity onPress={this.handlePress}>
           <View style={{paddingTop:5}}>
           </View>
          </TouchableOpacity>
            <View style={styles.buttons}>
             <View style={styles.button}>
              <LinearGradient style={{paddingLeft: 40, paddingRight: 40}} start={{x: 0, y: 0}} end={{x: 1, y: 0}} colors={['#FFCA12', '#C39515', '#D49C48']}>
               <Text style={styles.buttonText}>
                CONFIRMAR
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
});