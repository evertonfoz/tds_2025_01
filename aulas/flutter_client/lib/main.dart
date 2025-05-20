import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Login Flutter',
      theme: ThemeData(primarySwatch: Colors.blue),
      home: const LoginPage(),
    );
  }
}

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final emailController = TextEditingController();
  final senhaController = TextEditingController();
  String mensagem = '';

  Future<void> fazerLogin() async {
    final email = emailController.text;
    final senha = senhaController.text;

    final url = Uri.parse("http://10.55.0.91:5001/api/auth");
    final response = await http.post(
      url,
      headers: {"Content-Type": "application/json"},
      body: '{"name": "$email", "password": "$senha"}',
    );

    if (response.statusCode == 200) {
      final token = response.body;
      setState(() {
        mensagem = 'Login realizado com sucesso!';
      });
      debugPrint('Token: $token');

      // TODO: salvar token com SharedPreferences ou navegar para outra página
    } else {
      setState(() {
        mensagem = 'Usuário ou senha inválidos.';
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Login")),
      body: Padding(
        padding: const EdgeInsets.all(24.0),
        child: Column(
          children: [
            TextField(
              controller: emailController,
              decoration: const InputDecoration(labelText: "Email"),
            ),
            TextField(
              controller: senhaController,
              decoration: const InputDecoration(labelText: "Senha"),
              obscureText: true,
            ),
            const SizedBox(height: 20),
            ElevatedButton(onPressed: fazerLogin, child: const Text("Entrar")),
            const SizedBox(height: 20),
            Text(mensagem, style: const TextStyle(color: Colors.red)),
          ],
        ),
      ),
    );
  }
}
