import React, { Component } from 'react';
import {Actions} from 'react-native-router-flux';
import Icons from "react-native-vector-icons/dist/FontAwesome";
import Icons2 from 'react-native-vector-icons/dist/Feather';
import Icons3 from 'react-native-vector-icons/dist/MaterialIcons';


import {
  Platform,
  StyleSheet,
  Text,
  View,
  Button,
  TextInput,
  Image,
  ScrollView,
  Dimensions,
  TouchableHighlight
} from 'react-native';

const {height, width} = Dimensions.get("window");

export default class Menu extends Component<Props>{

  constructor(props){
    super(props);
    this.state = {
      token: this.props.token,
      correo: this.props.correo,
      contraseña: this.props.contraseña,
      charts: this.props.chartState,
      option: "",
      option2: "",
      option3: "",
      option4: "",
      option5: ""

    }
  }

  handleExit = () =>{
  Actions.pop();
  Actions.login();
 }

 handleConfiguration = () =>{
  this.props.onHandle();
  Actions.configuration({title:"Configuración", correo: this.state.correo});
  }
  
 handleBalance = () =>{
  this.props.onHandle();
  //Action a pantalla de Añadir saldo
 }

 handlePayment = () =>{
     this.props.onHandle();
     Actions.payment({title:"Solicitar pago", correo: this.state.correo});
  }

  handleOperaciones = () =>{
    this.props.onHandle();
    // Accion de operaciones
    // Actions.payment({title:"Realizar pago", correo: this.state.correo});
 }

 componentWillMount(){
 		this.setState({
 		 option: "Añadir saldo",
     option5: "Realizar pago",
 		 option2: "Configuración",
 		 option3: "Cambiar a Inglés",
 		 option4: "Salir"
 		})
 }

  render(){
  	return(
  		 	<View style={styles.container}>
  		 	  <View style={styles.userSection}>
	  		 	 <Text style={styles.text}>
            {this.state.correo}
	  		 	 </Text>
  		 	  </View>
  		 	  <View style={styles.optionSection}>
  		 	    <View style={styles.options}>
  		 	     <TouchableHighlight onPress={this.handleBalance}>
	  		 	    <View style={styles.option}>
	  		 	     <Icons2 style={styles.icon} name="plus-circle" color="#C39515" size={15}/>
	              <Text style={styles.text}>
	               {this.state.option}
		  		 	    </Text>
		  		    </View>
		  		 </TouchableHighlight>
		  		</View>
          <View style={styles.options}>
           <TouchableHighlight onPress={this.handlePayment}>
            <View style={styles.option}>
             <Icons2 style={styles.icon} name="check-circle" color="#C39515" size={15}/>
             <Text style={styles.text}>
              {this.state.option5}
             </Text>
            </View>
           </TouchableHighlight>
          </View>
  		 	    <View style={styles.options}>
  		 	     <TouchableHighlight onPress={this.handleConfiguration}>
	  		 	    <View style={styles.option}>
	  		 	     <Icons style={styles.icon} name="cogs" color="#C39515" size={15}/>
	                <Text style={styles.text}>
	                   {this.state.option2}
		  		 	</Text>
		  		    </View>
		  		 </TouchableHighlight>
		  		</View>
		  		<View style={styles.options}>
		  		 <TouchableHighlight onPress={this.handleOperaciones}>
	  		 	  <View style={styles.option}>
	  		 	   <Icons3 style={styles.icon} name="operaciones" color="#C39515" size={15}/>
	           <Text style={styles.text}>
	            {this.state.option3}
		  		 	 </Text>
		  		  </View>
		  		 </TouchableHighlight>
		  		</View>
		  		<View style={styles.options}>
		  		 <TouchableHighlight onPress={this.handleExit}>
	  		 	  <View style={styles.option}>
	  		 	   <Icons2 style={styles.icon} name="log-out" color="#C39515" size={15}/>
	           <Text style={styles.text}>
	            {this.state.option4}
		  		 	 </Text>
		  		  </View>
		  		 </TouchableHighlight>
		  		</View>
  		 	 </View>
  		   </View>
  		)
     }
 }

 const styles = StyleSheet.create({
  container:{
    flex: 1,
 	  backgroundColor: "black",
  },
  text:{
  fontSize: 15,
  fontWeight: 'bold',
  color: '#C39515',
  marginLeft: 5
  },
  userSection:{
  	flexDirection: "row",
  	justifyContent: "center",
  	alignItems: "center",
  	paddingVertical: 22

  },
  option:{
  	flexDirection: "row",
  	marginBottom: 10,
    alignItems: "center"
  },
  optionSection:{
  	marginTop: 5,
  	marginLeft: 5
  }
});