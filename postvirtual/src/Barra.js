import React from 'react';
import Icons from "react-native-vector-icons/dist/FontAwesome";
import Icons2 from "react-native-vector-icons/dist/MaterialCommunityIcons";
import {
  StyleSheet,
  Text,
  View,
  TouchableHighlight,
  Image
} from 'react-native';

const Barra = props =>{
		return(
			 <View style={styles.container}>
			  <TouchableHighlight onPress={props.onHandle}>
          <Icons name="bars" color="#C39515" size={25}/>
			  </TouchableHighlight>
        <TouchableHighlight onPress={props.onSwitch}>
          <Icons2 style={styles.icon} name="chart-areaspline" color="#C39515" size={25}/>
        </TouchableHighlight>
			 </View>
			)
	}

const styles = StyleSheet.create({
  container:{
 	flexDirection: "row",
 	height: 70,
 	alignItems: "center",
  justifyContent: "space-between",
 	paddingHorizontal: 15
  },
  image:{
    width: 120,
    height: 60
  }
})

export default Barra;