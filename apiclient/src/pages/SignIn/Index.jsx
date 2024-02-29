import React, { useState } from 'react';
import axios from 'axios';

export const SignIn = () => {
  const [signInData, setSignInData] = useState({ email: '', password: '' });
  const [registerData, setRegisterData] = useState({ email: '', username: '', password: '' });
  const [signInMessage, setSignInMessage] = useState('');
  const [registerMessage, setRegisterMessage] = useState('');

  const handleSignIn = async () => {
    try {
      const response = await axios.post('/Accounts/SignIn', signInData);
      localStorage.setItem('token', response.data.token);
      setSignInMessage(response.data.message);
    } catch (error) {
      setSignInMessage('Unable to sign in');
    }
  };

  const handleRegister = async () => {
    try {
      const response = await axios.post('/Accounts/register', registerData);
      setRegisterMessage(response.data.message);
    } catch (error) {
      setRegisterMessage('Unable to register');
    }
  };

  return (
    <div>
      <div>
        <h2>Sign In</h2>
        <input
          type="text"
          placeholder="Email"
          value={signInData.email}
          onChange={(e) => setSignInData({ ...signInData, email: e.target.value })}
        />
        <input
          type="password"
          placeholder="Password"
          value={signInData.password}
          onChange={(e) => setSignInData({ ...signInData, password: e.target.value })}
        />
        <button onClick={handleSignIn}>Sign In</button>
        <p>{signInMessage}</p>
      </div>

      <div>
        <h2>Register</h2>
        <input
          type="text"
          placeholder="Email"
          value={registerData.email}
          onChange={(e) => setRegisterData({ ...registerData, email: e.target.value })}
        />
        <input
          type="text"
          placeholder="Username"
          value={registerData.username}
          onChange={(e) => setRegisterData({ ...registerData, username: e.target.value })}
        />
        <input
          type="password"
          placeholder="Password"
          value={registerData.password}
          onChange={(e) => setRegisterData({ ...registerData, password: e.target.value })}
        />
        <button onClick={handleRegister}>Register</button>
        <p>{registerMessage}</p>
      </div>
    </div>
  );
};