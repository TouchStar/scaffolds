import sys, os, fnmatch, shutil

def findReplace(directory, find, replace, filePattern):
	#print '-------------------------------------------------'
	restart = True
	while restart:
		restart = False
		for path, dirs, files in os.walk(os.path.abspath(directory)):
			newpath = path.replace(find, replace)			
			if(newpath != path):
				os.rename(path, newpath)
				#print 'rename_dir[' + path + ']'
				restart = True
				break
	#print '-------------------------------------------------'
	for path, dirs, files in os.walk(os.path.abspath(directory)):
		for filename in fnmatch.filter(files, filePattern):
			if(filename == __file__):
				continue
			
			newfilename = filename.replace(find, replace)
			if(newfilename != filename):
				os.rename(os.path.join(path, filename), os.path.join(path, newfilename))
				filename = newfilename
				#print 'rename_filename[' + filename + ']'

			filepath = os.path.join(path, filename)
			with open(filepath) as f:
				s = f.read()

			if(s.find(find)):
				s = s.replace(find, replace)            
				filepath = filepath.replace(find, replace)

				#print 'changed_file[' + filepath + ']'
				with open(filepath, "w") as f:
					f.write(s)

def copytree(src, dst, symlinks=False, ignore=None):
    for item in os.listdir(src):
        s = os.path.join(src, item)
        d = os.path.join(dst, item)
        if os.path.isdir(s):
            shutil.copytree(s, d, symlinks, ignore)
        else:
            shutil.copy2(s, d)

if(len(sys.argv) == 1):
	print ("Generate.Library tool")	
	print ("Usage: %s Project.Name" % sys.argv[0])
	sys.exit(1)

projectName = sys.argv[1]

templateName = "Company.Library"

templatePath = os.path.join(os.getcwd(), templateName)
projectOutputPath = os.path.join(os.getcwd(), "Output")

# ensure path/Output exists.
if os.path.exists(projectOutputPath) == False:
	os.mkdir(projectOutputPath)	

projectPath = os.path.join(projectOutputPath, projectName)
if os.path.exists(projectPath):
	print ("Target ProjectPath %s already exists, please remove" % projectPath)
if os.path.exists(templatePath) == False:
	print ("Template not found, 'git reset --hard'")

os.mkdir(projectPath)
copytree(templatePath, projectPath)
findReplace(projectPath, templateName, projectName, "*.*")

print ("Generated: cd %s" % projectPath)
