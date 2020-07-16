import { Navigation } from 'react-native-navigation';
import { getIsLogged } from 'postvirtual/src/asyncStorage/user';

export default async () => {
    const isLogged = await getIsLogged();
    let rootConfig = {};
    if (isLogged) {
        rootConfig = {
            bottomTabs: {
                children: [
                    {
                       stack: {
                           children: [ 
                                component: {
                                    name: 'app.logged',
                                    options: {
                                        bottomTab: {
                                            text: 'Cuenta'
                                        },
                                        topBar: {
                                            title: {
                                                text: 'Cuenta'
                                            }
                                        }
                                    }
                                }
                            }
                        ]
                    }
                },
                {
                    stack: {
                        children: [
                            {
                                component: {
                                    name: 'app.logged',
                                    options: {
                                        bottomTab: {
                                            text: 'Pago'
                                        },
                                        topBar: {
                                            title: {
                                                text: 'Pago'
                                            }
                                        }
                                    }
                                }
                            }
                        ]
                    }
                }
            ]
        }        
    };

} else {
    rootConfig = {
        stack: {
            options: {
                topBar: {
                    visible: true
                }
            },
            children: [
                {
                    component: {
                        name: 'app.login'
                    }
                }
            ]
        }
    };
}
Navigation.setRoot({ root: rootConfig });
};       