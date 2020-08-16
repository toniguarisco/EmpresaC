import React, { Component } from 'react';
import {Actions} from 'react-native-router-flux';

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
      id: this.props.id,
      correo: this.props.correo,
      contraseña: this.props.contraseña,
      charts: this.props.chartState,
      option1: "",
      option2: "",
      option3: "",
      option4: ""

    }
  }

  handleExit = () =>{
  Actions.pop();
  Actions.login();
 }

 handlePerfil = () =>{
  this.props.onHandle();
  Actions.opciones({title:"Perfil", correo: this.state.correo, id: this.state.id});
  }

 handlePago = () =>{
     this.props.onHandle();
     Actions.pago({title:"Solicitar pago", correo: this.state.correo, id: this.state.id});
  }

 handleReintegro = () =>{
     this.props.onHandle();
     Actions.reintegro({title:"Reintegros", correo: this.state.correo, id: this.state.id});
  }

 componentWillMount(){
 		this.setState({
     option1: "SOLICITAR PAGO",
     option2: "REINTEGROS",
 		 option3: "PERFIL",
 		 option4: "SALIR"
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
	           <TouchableHighlight onPress={this.handlePago}>
	            <View style={styles.option}>
	             <Text style={styles.text}>
	              {this.state.option1}
	             </Text>
	            </View>
	           </TouchableHighlight>
	          </View>
	          <View style={styles.options}>
	           <TouchableHighlight onPress={this.handleReintegro}>
	            <View style={styles.option}>
	             <Text style={styles.text}>
	              {this.state.option2}
	             </Text>
	            </View>
	           </TouchableHighlight>
	          </View>
  		 	    <View style={styles.options}>
  		 	     <TouchableHighlight onPress={this.handlePerfil}>
	  		 	    <View style={styles.option}>
	                <Text style={styles.text}>
	                   {this.state.option3}
		  		 	</Text>
		  		    </View>
		  		 </TouchableHighlight>
		  		</View>
		  		<View style={styles.options}>
		  		 <TouchableHighlight onPress={this.handleExit}>
	  		 	  <View style={styles.option}>
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