import  {Editor} from './Editor';

var container = document.createElement('div');
container.setAttribute('style', 'width:100%;height:600px;');
document.body.appendChild(container);

new Editor().createEditor('test', container);