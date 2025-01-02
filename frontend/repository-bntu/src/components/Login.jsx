import { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const { login } = useAuth();
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('/api/auth/login', { email, password });
            const token = response.data.token;
            if (token) {
                const payload = JSON.parse(atob(token.split('.')[1]));
                const userRole = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
                document.cookie = `accessToken=${token}; path=/; secure; HttpOnly;`;
                login(userRole); navigate('/');
            } else {
                console.error('Token not received');
            }
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div className="mx-auto p-4 bg-primary min-h-screen flex justify-center items-center">
            <div className="bg-white p-8 rounded shadow-md w-full max-w-md">
                <h2 className="text-2xl font-bold mb-6 text-center">Вход</h2>
                <form onSubmit={handleSubmit} className="space-y-4">
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Логин</label>
                        <input
                            type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            className="mt-1 p-2 block w-full border border-gray-300 rounded-md shadow-sm"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Пароль</label>
                        <input
                            type="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            className="mt-1 p-2 block w-full border border-gray-300 rounded-md shadow-sm"
                            required
                        />
                    </div>
                    <button type="submit" className="w-full py-2 bg-green-500 text-white rounded hover:bg-green-600">Войти</button>
                </form>
            </div>
        </div>
    );
};

export default Login;
