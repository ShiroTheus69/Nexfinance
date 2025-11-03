# Guia de Solução de Problemas - NexFinance

## Problema: Erros de compilação com PO-UI

### Sintoma
Ao executar `npm run build`, aparecem erros como:
```
NG8001: 'po-page' is not a known element
NG8002: Can't bind to 'p-title'
```

### Causa
Incompatibilidade de versão entre Angular 20 e PO-UI 19.

### Solução

#### Opção 1: Downgrade do Angular para versão 19 (Recomendado)

1. Remova o diretório node_modules e package-lock.json:
```bash
rm -rf node_modules package-lock.json
```

2. Edite o `package.json` e ajuste as versões do Angular para 19:
```json
{
  "dependencies": {
    "@angular/animations": "^19.2.0",
    "@angular/common": "^19.2.0",
    "@angular/compiler": "^19.2.0",
    "@angular/core": "^19.2.0",
    "@angular/forms": "^19.2.0",
    "@angular/platform-browser": "^19.2.0",
    "@angular/platform-browser-dynamic": "^19.2.0",
    "@angular/router": "^19.2.0",
    "@po-ui/ng-components": "^19.29.0",
    "@po-ui/ng-templates": "^19.29.0"
  },
  "devDependencies": {
    "@angular-devkit/build-angular": "^19.2.0",
    "@angular/cli": "^19.2.0",
    "@angular/compiler-cli": "^19.2.0"
  }
}
```

3. Reinstale as dependências:
```bash
npm install --legacy-peer-deps
```

4. Teste a compilação:
```bash
npm run build
```

#### Opção 2: Aguardar atualização do PO-UI

Aguarde a TOTVS lançar uma versão do PO-UI compatível com Angular 20.

## Problema: Erro ao instalar dependências

### Sintoma
```
npm ERR! ERESOLVE unable to resolve dependency tree
```

### Solução
Use a flag `--legacy-peer-deps`:
```bash
npm install --legacy-peer-deps
```

## Problema: Aplicação não inicia

### Sintoma
Ao executar `npm start`, a aplicação não abre no navegador.

### Solução
1. Verifique se a porta 4200 está livre:
```bash
lsof -i :4200
```

2. Se estiver em uso, mate o processo ou use outra porta:
```bash
ng serve --port 4300
```

## Problema: Estilos do PO-UI não carregam

### Sintoma
A aplicação funciona mas os componentes não têm estilo.

### Solução
Verifique se o tema do PO-UI está importado em `src/styles.css`:
```css
@import '@po-ui/style/css/po-theme-default.min.css';
```

## Suporte

Para problemas adicionais:
- Documentação do PO-UI: https://po-ui.io/
- Issues do PO-UI no GitHub: https://github.com/po-ui/po-angular/issues
- Documentação do Angular: https://angular.dev/
