import React { Component } from 'react';
import { TextInput, View, Text, Button } from 'react-native';
import PropTypes from 'prop-types';
import Loader from 'postvirtual/src/components/common/Loader';

const LoginForm = ({ onChangeUsuario, onChangeClave, onSubmit, formData }) => (
    <View>
        <Loader loading={formData.sending} title="Iniciando sesion" />
        {formData.error && <Text>{formData.error}</Text>}
        <Text>Usuario</Text>
        <TextInput
            onChangeText={onChangeUsuario}
            value={formData.usuario}
            autoCapitalize="none"
        />
        <Text>Clave</Text>
        <TextInput
            onChangeText={onChangeClave}
            value={formData.clave}
            secureTextEntry
        />
        <Button
            onPress={onSubmit}
            title="Iniciar sesion"
            color="#841584"
        />
    </View>    
);

    LoginForm.propTypes = {
        onChangeUsuario: PropTypes.func.isRequired,
        onChangeClave: PropTypes.func.isRequired,
        onSubmit: PropTypes.func.isRequired,
        formData: PropTypes.object.isRequired
    };

export default LoginForm;
