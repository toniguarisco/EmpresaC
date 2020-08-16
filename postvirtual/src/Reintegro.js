import React, { Component } from 'react';
import {Actions} from 'react-native-router-flux';
import LinearGradient from 'react-native-linear-gradient';
import { Table, TableWrapper, Cell, Row, Rows} from 'react-native-table-component';
import * as shape from 'd3-shape'

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
      solicitante: "",
      monto: "",
      referencia: "",
      estatus: "",
      fecha: "",
      correo: this.props.correo,
      id: this.this.props.id,
      title:"",
      title2:"",
      title3:"",
      error:"",
      errorTipo:"",
      modalVisible: false,
      modalTitle: "",
      message: "",
      tableHead: "" ,
      tableData: []
    }
  }

  getUserData = async(correo) => {
    try {
      let response = await fetch(
        'http://ec2-18-234-178-93.compute-1.amazonaws.com/api/PostVirtual/Reintegros?usuarioId='+this.state.id,{
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
        let arrayObject = [ item.fecha, item.solicitante, item.monto, item.referencia, item.estatus ];
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

  this.getUserData(this.state.correo);

    this.setState({
      title: "SOLICITUDES DE REINTEGRO",
      title2: "ACEPTAR",
      title3: "DENEGAR",
      error: "Error",
      errorTipo: "Algún campo está vacío.",
      tableHead: ['Fecha', 'Usuario','Monto', 'Referencia', 'Estatus']
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

    const state = this.state;
    const element = (data, index) => (
      <TouchableOpacity onPress={() => this._alertIndex(index)}>
        <View style={styles.butons}>
          <Text style={styles.buttonText}>O</Text>
        </View>
      </TouchableOpacity>
    );

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
            <View style={{ flex: 1, flexDirection: 'row'}}>
                <View style={{flex: 1, flexDirection:"column"}}>
                  <View style={styles.container2}>
                    <Table borderStyle={{borderWidth: 2, borderColor: "#C39515"}}>
                      <Row data={state.tableHead} style={styles.head} textStyle={styles.text}/>
                      {
                      state.tableData.map((rowData, index) => (
                        <TableWrapper key={index} style={styles.row}>
                          {
                            rowData.map((cellData, cellIndex) => (
                              <Cell key={cellIndex} data={cellIndex === 5 ? element(cellData, index) : cellData} style={{backgroundColor: "black"}} textStyle={styles.text}/>
                            ))
                          }
                        </TableWrapper>
                      ))
                    }
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
 
 row: {  
  height: 28  
},

 title:{
  flex: 1,
  height: 30
 },
});