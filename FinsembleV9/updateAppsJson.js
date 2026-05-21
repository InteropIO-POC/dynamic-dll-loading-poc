const fs = require('fs');
const path = require('path');

const projectRoot = path.resolve(process.cwd(), '..');
const target = path.join(__dirname, 'public', 'configs', 'application', 'apps.json');

let content = fs.readFileSync(target, 'utf8');
const updated = content.replace(/<PROJECT_ROOT>/g, projectRoot.replace(/\\/g, '\\\\'));

if (content !== updated) {
	fs.writeFileSync(target, updated, 'utf8');
	console.log(`postinstall: replaced <PROJECT_ROOT> with ${projectRoot} in apps.json`);
} else {
	console.log('postinstall: no <PROJECT_ROOT> tokens found in apps.json');
}
