import React, { Component } from 'react';
import {Actions} from 'react-native-router-flux';
import LinearGradient from 'react-native-linear-gradient';
import {
  Menu,
  MenuOptions,
  MenuOption,
  MenuTrigger,
} from 'react-native-popup-menu';

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
      correoDestino: "",
      monto: "",
      referencia: "",
      usuario: "",
      fecha: "",
      correo: this.props.correo,
      id: this.this.props.id,
      title:"",
      error:"",
      errorTipo:"",
      modalVisible: false,
      modalTitle: "",
      message: ""
    }
  }

  handlePress = () =>{
  if ((this.state.correoDestino!="")&&(this.state.monto!="")&&(this.state.referencia!="")){
   Actions.pop();
  }else{
    this.setModalVisible(this.state.error, this.state.errorTipo);
  }
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

renderItem = ({item}) => (
  <TouchableOpacity>
    <View style={styles.item}>
      <View></View>
      <Text># {item.referencia} | {item.fecha}</Text>
      <Text>{item.usuario}    $ {item.monto}</Text>
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

 componentWillMount(){
    this.setState({
      title: "HISTORIAL DE OPERACIONES",
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