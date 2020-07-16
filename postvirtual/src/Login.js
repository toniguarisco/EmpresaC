import React, { Component } from 'react';
import { login as apiLogin } from 'postvirtual/src/services/api';
import { setUser } from 'postvirtual/src/asyncStorage/user';
import LoginForm from 'postvirtual/src/components/auth/LoginForm';
import setNavigationRoot from 'postvirtual/src/services/setNavigationRoot';

class LoginScreen extends Component {
    state = {
        usuario: '',
        clave: '',
        error: null,
        sending: false
    };

    onChangeUsuario = usuario => this.setState({ usuario });

    onChangeClave = clave => this.setState({ clave });

    onSubmit = async () => {
        const { usuario, clave } = this.state;
        this.setState({ sending: true });
        try {
            const result = await apiLogin({ username: usuario, password: clave });
            await setUser ({ ...result,usuario});
            setNavigationRoot();
        } catch (error) {
            this.setState({ error: error.message });    
        } finally {
            this.setState({ sending: false });
        }
    };

    render() {
        return (
            <LoginForm
                onChangeUsuario={this.onChangeUsuario}
                onChangeClave={this.onChangeClave}
                onSubmit={this.onSubmit}
                formData={this.state}
            />    
        );
    }
}

export default LoginScreen;